#region usings

using SIO=System.IO;

#endregion

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Security.AccessControl;
	using System.Transactions;
	using Core.Services.FileSystem;
	using Microsoft.Win32.SafeHandles;
	using Native;
	using SIO;

	public class TransactionalFileService : IFileService
	{
		private readonly IProxyFactory factory;

		public TransactionalFileService(IProxyFactory factory)
		{
			this.factory = factory;
		}

		#region IFileService Members

		public virtual bool FileExists(string file)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
			using (var handle = this.GetFileHandleForInfo(file, tranHandle))
				return !handle.IsInvalid;
		}

		public virtual bool DirectoryExists(string directory)
		{
			return this.FileExists(directory);
		}

		public virtual void DeleteFile(IFile file)
		{
			DeleteFile(file.Path);
		}

		public virtual void DeleteFile(string file)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
				NativeMethods.DeleteFileTransacted(file, tranHandle);
		}

		public virtual void MoveFile(string source, string destination)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
				NativeMethods.MoveFileTransacted(source, destination, IntPtr.Zero, IntPtr.Zero,
				                                 NativeMethods.MoveFileFlags.MOVEFILE_REPLACE_EXISTING, tranHandle);
		}

		public virtual void MoveFile(IFile source, string destination)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
				NativeMethods.MoveFileTransacted(source.Path, destination, IntPtr.Zero, IntPtr.Zero,
				                                 NativeMethods.MoveFileFlags.MOVEFILE_REPLACE_EXISTING, tranHandle);
		}

		public virtual void CopyFile(string source, string destination)
		{
			bool pbCancel = false;
			using (var tranHandle = this.GetKtmTransactionHandle())
				NativeMethods.CopyFileTransacted(source, destination, IntPtr.Zero, IntPtr.Zero, ref pbCancel,
				                                 NativeMethods.CopyFileFlags.COPY_FILE_FAIL_IF_EXISTS, tranHandle);
		}

		public virtual void CopyFile(IFile source, string destination)
		{
			CopyFile(source, destination);
		}

		public Stream OpenFileForRead(string source)
		{
			return this.OpenFile(source, FileMode.Open, FileAccess.Read, FileShare.None);
		}

		public Stream OpenFileForRead(IFile file)
		{
			return OpenFileForRead(file.Path);
		}

		public Stream OpenFileForWrite(string source)
		{
			return this.OpenFile(source, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
		}

		public Stream OpenFileForWrite(IFile file)
		{
			return OpenFileForWrite(file.Path);
		}

		public Stream OpenFile(string path, FileMode fileMode, FileAccess access, FileShare fileShare)
		{
			return this.OpenFileUnManaged(path, fileMode, access, fileShare);
		}

		public IFile GetFile(string file)
		{
			NativeMethods.WIN32_FIND_DATA findData;
			using (var tranHandle = this.GetKtmTransactionHandle())
			using (var fileHandle = this.GetFileHandleForInfo(file, tranHandle, out findData))
			{
				if (!fileHandle.IsInvalid)
					return this.factory.CreateFileWithProxy(this, file, findData);
				else
					throw new FileNotFoundException();
			}
		}

		public IDirectory GetDirectory(string directory)
		{
			NativeMethods.WIN32_FIND_DATA findData;
			using (var tranHandle = this.GetKtmTransactionHandle())
			using (var fileHandle = this.GetFileHandleForInfo(directory, tranHandle, out findData))
			{
				if (!fileHandle.IsInvalid)
					return this.factory.CreateDirectoryWithProxy(this, directory);
				else
					throw new DirectoryNotFoundException();
			}
		}

		public IFile CreateFile(string file, FileMode fileMode, FileAccess fileAccess, FileShare fileShare,
		                        FileSystemRights fileSystemRights, FileOptions fileOptions, FileSecurity fileSecurity)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
			{
				int dwFlagsAndAttributes = (int) fileOptions;
				dwFlagsAndAttributes |= 0x100000;
				NativeMethods.FileAccess faccess = NativeFileEnums.TranslateFileAccess(fileAccess);
				NativeMethods.FileShare fshare = NativeFileEnums.TranslateFileShare(fileShare);
				NativeMethods.FileMode fmode = NativeFileEnums.TranslateFileMode(fileMode);
				using (SafeFileHandle fileHandle = NativeMethods.CreateFileTransacted(file, faccess, fshare, IntPtr.Zero, fmode,
				                                                                      dwFlagsAndAttributes, IntPtr.Zero, tranHandle,
				                                                                      IntPtr.Zero, IntPtr.Zero))
				{
					if (fileHandle.IsInvalid)
						throw new InvalidOperationException();
				}
				return this.GetFile(file);
			}
		}

		public IFile CreateFile(string file, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
		{
			return this.CreateFile(file, fileMode, fileAccess, fileShare, 0, FileOptions.None, null);
		}

		public IFile CreateFile(string file, FileMode fileMode)
		{
			FileAccess access = this.GetFileAccessFromFileMode(fileMode);
			return this.CreateFile(file, fileMode, access);
		}

		public IFile CreateFile(string file, FileMode fileMode, FileAccess fileAccess)
		{
			return this.CreateFile(file, fileMode, fileAccess, FileShare.Read);
		}


		public IFile CreateFile(string file)
		{
			return this.CreateFile(file, FileMode.CreateNew);
		}

		public IEnumerable<IFileSystemInfo> SearchDirectory(string directory, string searchPattern,
		                                                    SearchOptions searchOptions, SearchLocation searchLocation)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
			{
				NativeMethods.WIN32_FIND_DATA win32findData;
				var directoriesToBeSearched = new List<string>(8) {directory};

				var output = new List<IFileSystemInfo>();
				while (directoriesToBeSearched.Count > 0)
				{
					var count = directoriesToBeSearched.Count;
					directory = directoriesToBeSearched[count - 1];
					directoriesToBeSearched.RemoveAt(count - 1);

					using (var directoryHandle = this.GetFileHandleForInfo(
						directory + Path.DirectorySeparatorChar + @"*", tranHandle, out win32findData))
					{
						while (NativeMethods.FindNextFile(directoryHandle, out win32findData))
						{
							if (win32findData.cFileName.Equals("..") ||
								win32findData.cFileName.Equals("."))
								continue;
							bool isFile = 0 == (win32findData.dwFileAttributes & 0x10);
							string relative = directory + Path.DirectorySeparatorChar + win32findData.cFileName;
							if (isFile & (searchOptions & SearchOptions.File) != 0)
								output.Add(this.factory.CreateFileWithProxy(this, relative, win32findData));
							else if (!isFile)
							{
								if (searchLocation == SearchLocation.Recursive)
									directoriesToBeSearched.Add(relative);
								if ((searchOptions & SearchOptions.Directory) != 0)
									output.Add(this.factory.CreateDirectoryWithProxy(this, relative));
							}
						}
					}
				}
				this.SortListByTypeAndName(output);
				return new ReadOnlyCollection<IFileSystemInfo>(output);
			}
		}

		#endregion

		protected virtual bool IsInTransaction()
		{
			return Transaction.Current != null;
		}

		protected virtual KtmTransactionHandle GetKtmTransactionHandle()
		{
			return KtmTransactionHandle.CreateKtmTransactionHandle();
		}

		protected virtual Stream OpenFileUnManaged(string source, FileMode fileMode, FileAccess fileAccess,
		                                           FileShare fileShare)
		{
			using (var tranHandle = this.GetKtmTransactionHandle())
			{
				var fileHandle = this.GetFileHandle(source, tranHandle, fileMode, fileAccess, fileShare);
				var stream = new FileStream(fileHandle, fileAccess);
				if (fileMode == FileMode.Append)
					stream.Position = stream.Length;
				return stream;
			}
		}

		protected virtual SafeFileHandle GetFileHandle(string source, KtmTransactionHandle tranHandle, FileMode fileMode,
		                                               FileAccess fileAccess, FileShare fileShare)
		{
			return NativeMethods.CreateFileTransacted(
				source, NativeFileEnums.TranslateFileAccess(fileAccess),
				NativeFileEnums.TranslateFileShare(fileShare), IntPtr.Zero,
				NativeFileEnums.TranslateFileMode(fileMode), 0, IntPtr.Zero,
				tranHandle, IntPtr.Zero, IntPtr.Zero);
		}

		protected virtual SafeFileHandle GetFileHandleForInfo(string source, KtmTransactionHandle tranHandle,
		                                                      out NativeMethods.WIN32_FIND_DATA data)
		{
			var safeHandle = NativeMethods.FindFirstFileTransacted(source, NativeMethods.FINDEX_INFO_LEVELS.FindExInfoStandard,
			                                                       out data,
			                                                       NativeMethods.FINDEX_SEARCH_OPS.FindExSearchNameMatch,
			                                                       IntPtr.Zero, 0, tranHandle);
			return safeHandle;
		}

		protected virtual SafeFileHandle GetFileHandleForInfo(string source, KtmTransactionHandle tranHandle)
		{
			NativeMethods.WIN32_FIND_DATA data;
			return this.GetFileHandleForInfo(source, tranHandle, out data);
		}

		protected virtual FileAccess GetFileAccessFromFileMode(FileMode fileMode)
		{
			return fileMode == FileMode.Append ? FileAccess.Write : FileAccess.ReadWrite;
			//switch (fileMode)
			//{
			//    case FileMode.Append:
			//        return FileAccess.Write;
			//    case FileMode.CreateNew:
			//    case FileMode.Create:
			//    case FileMode.Open:
			//    case FileMode.OpenOrCreate:
			//    case FileMode.Truncate:
			//    default:
			//        return FileAccess.ReadWrite;
			//}
		}

		protected virtual void SortListByTypeAndName(List<IFileSystemInfo> output)
		{
			output.Sort(delegate(IFileSystemInfo info1, IFileSystemInfo info2)
			            	{
			            		if (info1.Type == FileSystemType.Directory && info2.Type == FileSystemType.File)
			            			return 1;
			            		else if (info1.Type == FileSystemType.File && info2.Type == FileSystemType.Directory)
			            			return -1;
			            		else
			            			return info1.Path.CompareTo(info2.Path);
			            	});
		}
	}
}