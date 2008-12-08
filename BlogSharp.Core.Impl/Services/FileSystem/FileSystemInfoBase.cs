using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public abstract class FileSystemInfoBase:IFileSystemInfo
	{
		public FileSystemInfoBase(FileSystemInfo fileSystemInfo)
		{
			this.fileSystemInfo = fileSystemInfo;

		}

		private readonly FileSystemInfo fileSystemInfo;
		#region IFileSystemInfo Members

		public string Name
		{
			get { return this.fileSystemInfo.Name; }
		}

		public FileSystemType Type
		{
			get { return fileSystemInfo is FileInfo ? FileSystemType.File : FileSystemType.Directory; }
		}

		public abstract IDirectory Parent { get; }

		#endregion
		protected virtual FileSystemInfo FileSystemInfo
		{
			get { return this.fileSystemInfo; }
		}


		#region IFileSystemInfo Members


		public string Path
		{
			get { return this.fileSystemInfo.FullName; }
		}

		public string GetRelativePath(string root)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
