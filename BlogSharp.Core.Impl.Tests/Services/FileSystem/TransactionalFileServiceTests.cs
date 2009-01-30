using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using BlogSharp.Core.Impl.Services.FileSystem;
using BlogSharp.Core.Impl.Services.FileSystem.Castle;
using BlogSharp.Core.Services.FileSystem;
using Xunit;
using SIO = System.IO;

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	public class TransactionalFileServiceTests : IDisposable
	{
		private readonly string assemblyDirectory;
		private readonly string assemblyFile;
		private readonly string assemblyFileName;
		private readonly IFileService fileService;
		private readonly string textfile;

		public TransactionalFileServiceTests()
		{
			fileService = new TransactionalFileService(new CastleProxyFactory());
			assemblyFile = GetType().Assembly.Location;
			assemblyDirectory = new FileInfo(assemblyFile).DirectoryName;
			assemblyFileName = new FileInfo(assemblyFile).Name;
			textfile = "mytextfile.txt";
			SIO.File.Delete(textfile);
			using (StreamWriter sw = SIO.File.CreateText(textfile))
			{
				sw.Write("blah");
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			SIO.File.Delete(textfile);
		}

		#endregion

		[Fact]
		public void Throws_exception_outside_of_the_transaction()
		{
			Assert.Throws<InvalidOperationException>(() => fileService.FileExists(assemblyFileName));
		}

		[Fact]
		public void Can_see_if_file_exists()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				Assert.True(fileService.FileExists(assemblyFile));
				Assert.False(fileService.FileExists("asdasdasd"));
			}
		}

		[Fact]
		public void Can_see_if_directory_exists()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				Assert.True(fileService.DirectoryExists(assemblyDirectory));
				Assert.False(fileService.DirectoryExists("asdasdasd"));
			}
		}

		[Fact]
		public void Returns_correct_file_if_found()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				IFile file = fileService.GetFile(assemblyFile);
				Assert.Equal(assemblyFileName, file.Name);
			}
		}

		[Fact]
		public void Throws_exception_if_file_not_found()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				Assert.Throws<FileNotFoundException>(() => fileService.GetFile("asdadsdas"));
			}
		}

		[Fact]
		public void File_created_in_transaction_should_exist_in_transaction()
		{
			string fileName = "newFile.file";
			string currentlyExistingFile = assemblyFile;
			string nonExistingFile = "blah.file";

			using (var scope = new TransactionScope())
			{
				IFile file = fileService.CreateFile(fileName);
				Assert.NotNull(file);
				Assert.True(fileService.FileExists(fileName));
				Assert.True(fileService.FileExists(currentlyExistingFile));
				Assert.False(fileService.FileExists(nonExistingFile));
				Assert.False(System.IO.File.Exists(fileName), "This file shouldn't exist out of transaction");
			}
		}

		[Fact]
		public void File_should_exist_outside_of_transaction_after_commit()
		{
			string fileName = "newFile.file";
			string currentlyExistingFile = assemblyFile;
			string nonExistingFile = "blah.file";
			SIO.File.Delete(fileName);
			SIO.File.Delete(nonExistingFile);
			using (var scope = new TransactionScope())
			{
				fileService.CreateFile(fileName);
				Assert.True(fileService.FileExists(fileName));
				Assert.False(System.IO.File.Exists(fileName), "This file shouldn't exist out of transaction");
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(fileName), "The file should exist since the scope is completed");
		}

		[Fact]
		public void Can_create_transactional_file()
		{
			string fileName = "newFile.file";
			SIO.File.Delete(fileName);
			using (var scope = new TransactionScope())
			{
				var file = fileService.CreateFile(fileName);
				Assert.True(fileService.FileExists(fileName));
				Assert.False(SIO.File.Exists(fileName));
			}
			Assert.False(SIO.File.Exists(fileName));
			SIO.File.Delete(fileName);
			using (var scope = new TransactionScope())
			{
				var file = fileService.CreateFile(fileName);
				Assert.NotNull(file);
				Assert.True(fileService.FileExists(fileName));
				Assert.False(SIO.File.Exists(fileName));
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(fileName));
			SIO.File.Delete(fileName);
		}

		[Fact]
		public void Can_get_transactional_file_in_transaction()
		{
			string fileName = "newFile.file";
			SIO.File.Delete(fileName);
			using (var scope = new TransactionScope())
			{
				var file = fileService.CreateFile(fileName);
				IFile gotFile = fileService.GetFile(fileName);
				Assert.NotNull(gotFile);
				Assert.False(SIO.File.Exists(fileName));
			}
			Assert.False(SIO.File.Exists(fileName));
		}

		[Fact]
		public void Can_move_file_in_transaction()
		{
			string fileName = "newFile.file";
			string destination = "merve.file";
			SIO.File.Delete(destination);
			SIO.File.Delete(fileName);
			SIO.File.Create(fileName).Dispose();
			using (var scope = new TransactionScope())
			{
				fileService.MoveFile(fileName, destination);
				Assert.False(SIO.File.Exists(destination));
				Assert.True(fileService.FileExists(destination));
				Assert.False(fileService.FileExists(fileName));
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(destination));
			SIO.File.Delete(fileName);
			SIO.File.Delete(destination);
		}

		[Fact]
		public void Can_copy_file_in_transaction()
		{
			string fileName = "newFile.file";
			string destination = "merve.file";
			SIO.File.Delete(destination);
			SIO.File.Delete(fileName);
			SIO.File.Create(fileName).Dispose();
			using (var scope = new TransactionScope())
			{
				fileService.CopyFile(fileName, destination);
				Assert.False(SIO.File.Exists(destination));
				Assert.True(fileService.FileExists(destination));
				Assert.True(fileService.FileExists(fileName));
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(destination));
			Assert.True(SIO.File.Exists(fileName));
			SIO.File.Delete(fileName);
			SIO.File.Delete(destination);
		}


		private string GetFileContentTransactional(string fileName)
		{
			string data;
			using (var fileStream = fileService.OpenFileForRead(textfile))
			using (var sr = new StreamReader(fileStream))
				data = sr.ReadLine();
			return data;
		}

		private string GetFileContentNonTransactional(string fileName)
		{
			string data;
			using (var sr = new StreamReader(fileName))
				data = sr.ReadLine();
			return data;
		}


		[Fact]
		public void Open_read_can_return_stream_with_file_content()
		{
			using (var scope = new TransactionScope())
			{
				string data;
				using (var fileStream = fileService.OpenFileForRead(textfile))
				{
					Assert.True(fileStream.CanRead);
					Assert.False(fileStream.CanWrite);
					using (var sr = new StreamReader(fileStream))
						data = sr.ReadLine();
				}
				Assert.Equal("blah", data);
			}
		}

		[Fact]
		public void Open_write_returns_stream_to_be_written()
		{
			string data;
			using (TransactionScope scope = new TransactionScope())
			{
				using (var fileStream = fileService.OpenFileForWrite(textfile))
				{
					Assert.True(fileStream.CanWrite);
					Assert.False(fileStream.CanRead);
					Assert.True(fileStream.CanWrite);
					fileStream.Write(new byte[] {126}, 0, 1);
				}
				data = GetFileContentTransactional(textfile);
				Assert.Equal("~lah", data);
			}
			data = GetFileContentNonTransactional(textfile);
			Assert.Equal("blah", data);
		}

		[Fact]
		public void Open_with_append_write_returns_stream()
		{
			string data;
			using (TransactionScope scope = new TransactionScope())
			{
				using (var fileStream = fileService.OpenFile(textfile, FileMode.Append, FileAccess.Write, FileShare.None))
				{
					Assert.Equal(fileStream.Position, fileStream.Length);
					Assert.True(fileStream.CanWrite);
					Assert.False(fileStream.CanRead);
					fileStream.Write(new byte[] {126}, 0, 1);
				}

				data = GetFileContentTransactional(textfile);
				Assert.Equal("blah~", data);
			}
			data = GetFileContentNonTransactional(textfile);
			Assert.Equal("blah", data);
		}

		[Fact]
		public void Open_with_truncate_write_returns_stream()
		{
			string data;
			using (TransactionScope tran = new TransactionScope())
			{
				using (var fileStream = fileService.OpenFile(textfile, FileMode.Truncate, FileAccess.Write, FileShare.None))
				{
					Assert.Equal(fileStream.Position, 0);
					Assert.True(fileStream.CanWrite);
					Assert.False(fileStream.CanRead);
					fileStream.Write(new byte[] {126}, 0, 1);
				}
				data = GetFileContentTransactional(textfile);
				Assert.Equal("~", data);
			}
			data = GetFileContentNonTransactional(textfile);
			Assert.Equal("blah", data);
		}

		[Fact]
		public void Open_with_truncate_returns_stream_with_write_only()
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (var fileStream = fileService.OpenFile(textfile, FileMode.Truncate,
				                                             FileAccess.Write, FileShare.ReadWrite))
				{
					Assert.False(fileStream.CanRead);
					Assert.True(fileStream.CanWrite);
					Assert.True(fileStream.CanSeek);
				}
			}
		}

		[Fact]
		public void Search_recursive_should_search_recursive()
		{
			if (SIO.Directory.Exists("r"))
				SIO.Directory.Delete("r", true);
			DirectoryInfo dirInfo = System.IO.Directory.CreateDirectory("r");
			DirectoryInfo sub1 = dirInfo.CreateSubdirectory("sub1");
			DirectoryInfo sub2 = dirInfo.CreateSubdirectory("sub2");
			string seperator = Path.DirectorySeparatorChar.ToString();
			SIO.File.Create(sub1.FullName + seperator + "b.txt");
			SIO.File.Create(sub2.FullName + seperator + "a.txt");
			using (TransactionScope tran = new TransactionScope())
			{
				IEnumerable<IFileSystemInfo> files = fileService.SearchDirectory(dirInfo.FullName, "*.*", SearchOptions.File,
				                                                                 SearchLocation.Recursive);
				Assert.Equal(2, files.Count());
				EnumerablePathEquals(files, dirInfo.FullName, new[]
				                                              	{
				                                              		"sub1" + seperator + "b.txt",
				                                              		"sub2" + seperator + "a.txt",
				                                              	});
				Transaction.Current.Rollback();
			}
		}

		private void EnumerablePathEquals(IEnumerable<IFileSystemInfo> files, string root, string[] toBeCompared)
		{
			int i = 0;
			string seperator = Path.DirectorySeparatorChar.ToString();
			foreach (var s in files)
				Assert.Equal(root + seperator + toBeCompared[i++], s.Path);
		}
	}
}