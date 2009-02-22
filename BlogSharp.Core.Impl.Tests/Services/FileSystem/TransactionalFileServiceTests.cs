#region usings

using SIO = System.IO;

#endregion

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Transactions;
	using Core.Services.FileSystem;
	using Impl.Services.FileSystem;
	using Impl.Services.FileSystem.Castle;
	using NUnit.Framework;
	using SIO;

	[TestFixture]
	public class TransactionalFileServiceTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.fileService = new TransactionalFileService(new CastleProxyFactory());
			this.assemblyFile = this.GetType().Assembly.Location;
			this.assemblyDirectory = new FileInfo(this.assemblyFile).DirectoryName;
			this.assemblyFileName = new FileInfo(this.assemblyFile).Name;
			this.textfile = "mytextfile.txt";
			SIO.File.Delete(this.textfile);
			using (StreamWriter sw = SIO.File.CreateText(this.textfile))
			{
				sw.Write("blah");
			}
		}

		[TearDown]
		public void TearDown()
		{
			SIO.File.Delete(this.textfile);
		}

		#endregion

		private string assemblyDirectory;
		private string assemblyFile;
		private string assemblyFileName;
		private IFileService fileService;
		private string textfile;

		private string GetFileContentTransactional(string fileName)
		{
			string data;
			using (var fileStream = this.fileService.OpenFileForRead(this.textfile))
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

		private void EnumerablePathEquals(IEnumerable<IFileSystemInfo> files, string root, string[] toBeCompared)
		{
			int i = 0;
			string seperator = Path.DirectorySeparatorChar.ToString();
			foreach (var s in files)
				Assert.That(s.Path, Is.EqualTo(root + seperator + toBeCompared[i++]));
		}

		[Test]
		public void Can_copy_file_in_transaction()
		{
			string fileName = "newFile.file";
			string destination = "merve.file";
			SIO.File.Delete(destination);
			SIO.File.Delete(fileName);
			SIO.File.Create(fileName).Dispose();
			using (var scope = new TransactionScope())
			{
				this.fileService.CopyFile(fileName, destination);
				Assert.False(SIO.File.Exists(destination));
				Assert.True(this.fileService.FileExists(destination));
				Assert.True(this.fileService.FileExists(fileName));
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(destination));
			Assert.True(SIO.File.Exists(fileName));
			SIO.File.Delete(fileName);
			SIO.File.Delete(destination);
		}

		[Test]
		public void Can_create_transactional_file()
		{
			string fileName = "newFile.file";
			SIO.File.Delete(fileName);
			using (var scope = new TransactionScope())
			{
				var file = this.fileService.CreateFile(fileName);
				Assert.True(this.fileService.FileExists(fileName));
				Assert.False(SIO.File.Exists(fileName));
			}
			Assert.False(SIO.File.Exists(fileName));
			SIO.File.Delete(fileName);
			using (var scope = new TransactionScope())
			{
				var file = this.fileService.CreateFile(fileName);
				Assert.NotNull(file);
				Assert.True(this.fileService.FileExists(fileName));
				Assert.False(SIO.File.Exists(fileName));
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(fileName));
			SIO.File.Delete(fileName);
		}

		[Test]
		public void Can_get_transactional_file_in_transaction()
		{
			string fileName = "newFile.file";
			SIO.File.Delete(fileName);
			using (var scope = new TransactionScope())
			{
				var file = this.fileService.CreateFile(fileName);
				IFile gotFile = this.fileService.GetFile(fileName);
				Assert.NotNull(gotFile);
				Assert.False(SIO.File.Exists(fileName));
			}
			Assert.False(SIO.File.Exists(fileName));
		}

		[Test]
		public void Can_move_file_in_transaction()
		{
			string fileName = "newFile.file";
			string destination = "merve.file";
			SIO.File.Delete(destination);
			SIO.File.Delete(fileName);
			SIO.File.Create(fileName).Dispose();
			using (var scope = new TransactionScope())
			{
				this.fileService.MoveFile(fileName, destination);
				Assert.False(SIO.File.Exists(destination));
				Assert.True(this.fileService.FileExists(destination));
				Assert.False(this.fileService.FileExists(fileName));
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(destination));
			SIO.File.Delete(fileName);
			SIO.File.Delete(destination);
		}

		[Test]
		public void Can_see_if_directory_exists()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				Assert.True(this.fileService.DirectoryExists(this.assemblyDirectory));
				Assert.False(this.fileService.DirectoryExists("asdasdasd"));
			}
		}

		[Test]
		public void Can_see_if_file_exists()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				Assert.True(this.fileService.FileExists(this.assemblyFile));
				Assert.False(this.fileService.FileExists("asdasdasd"));
			}
		}

		[Test]
		public void File_created_in_transaction_should_exist_in_transaction()
		{
			string fileName = "newFile.file";
			string currentlyExistingFile = this.assemblyFile;
			string nonExistingFile = "blah.file";

			using (var scope = new TransactionScope())
			{
				IFile file = this.fileService.CreateFile(fileName);
				Assert.NotNull(file);
				Assert.True(this.fileService.FileExists(fileName));
				Assert.True(this.fileService.FileExists(currentlyExistingFile));
				Assert.False(this.fileService.FileExists(nonExistingFile));
				Assert.False(System.IO.File.Exists(fileName), "This file shouldn't exist out of transaction");
			}
		}

		[Test]
		public void File_should_exist_outside_of_transaction_after_commit()
		{
			string fileName = "newFile.file";
			string currentlyExistingFile = this.assemblyFile;
			string nonExistingFile = "blah.file";
			SIO.File.Delete(fileName);
			SIO.File.Delete(nonExistingFile);
			using (var scope = new TransactionScope())
			{
				this.fileService.CreateFile(fileName);
				Assert.True(this.fileService.FileExists(fileName));
				Assert.False(System.IO.File.Exists(fileName), "This file shouldn't exist out of transaction");
				scope.Complete();
			}
			Assert.True(SIO.File.Exists(fileName), "The file should exist since the scope is completed");
		}


		[Test]
		public void Open_read_can_return_stream_with_file_content()
		{
			using (var scope = new TransactionScope())
			{
				string data;
				using (var fileStream = this.fileService.OpenFileForRead(this.textfile))
				{
					Assert.True(fileStream.CanRead);
					Assert.False(fileStream.CanWrite);
					using (var sr = new StreamReader(fileStream))
						data = sr.ReadLine();
				}
				Assert.That(data, Is.EqualTo("blah"));
			}
		}

		[Test]
		public void Open_with_append_write_returns_stream()
		{
			string data;
			using (TransactionScope scope = new TransactionScope())
			{
				using (var fileStream = this.fileService.OpenFile(this.textfile, FileMode.Append, FileAccess.Write, FileShare.None))
				{
					Assert.That(fileStream.Position, Is.EqualTo(fileStream.Length));
					Assert.True(fileStream.CanWrite);
					Assert.False(fileStream.CanRead);
					fileStream.Write(new byte[] {126}, 0, 1);
				}

				data = this.GetFileContentTransactional(this.textfile);
				Assert.That(data, Is.EqualTo("blah~"));
			}
			data = this.GetFileContentNonTransactional(this.textfile);
			Assert.That(data, Is.EqualTo("blah"));
		}

		[Test]
		public void Open_with_truncate_returns_stream_with_write_only()
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (var fileStream = this.fileService.OpenFile(this.textfile, FileMode.Truncate,
				                                                  FileAccess.Write, FileShare.ReadWrite))
				{
					Assert.False(fileStream.CanRead);
					Assert.True(fileStream.CanWrite);
					Assert.True(fileStream.CanSeek);
				}
			}
		}

		[Test]
		public void Open_with_truncate_write_returns_stream()
		{
			string data;
			using (TransactionScope tran = new TransactionScope())
			{
				using (
					var fileStream = this.fileService.OpenFile(this.textfile, FileMode.Truncate, FileAccess.Write, FileShare.None))
				{
					Assert.That(0, Is.EqualTo(fileStream.Position));
					Assert.True(fileStream.CanWrite);
					Assert.False(fileStream.CanRead);
					fileStream.Write(new byte[] {126}, 0, 1);
				}
				data = this.GetFileContentTransactional(this.textfile);
				Assert.That(data, Is.EqualTo("~"));
			}
			data = this.GetFileContentNonTransactional(this.textfile);
			Assert.That(data, Is.EqualTo("blah"));
		}

		[Test]
		public void Open_write_returns_stream_to_be_written()
		{
			string data;
			using (TransactionScope scope = new TransactionScope())
			{
				using (var fileStream = this.fileService.OpenFileForWrite(this.textfile))
				{
					Assert.True(fileStream.CanWrite);
					Assert.False(fileStream.CanRead);
					Assert.True(fileStream.CanWrite);
					fileStream.Write(new byte[] {126}, 0, 1);
				}
				data = this.GetFileContentTransactional(this.textfile);
				Assert.That(data, Is.EqualTo("~lah"));
			}
			data = this.GetFileContentNonTransactional(this.textfile);
			Assert.That(data, Is.EqualTo("blah"));
		}

		[Test]
		public void Returns_correct_file_if_found()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				IFile file = this.fileService.GetFile(this.assemblyFile);
				Assert.That(file.Name, Is.EqualTo(this.assemblyFileName));
			}
		}

		[Test]
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
				IEnumerable<IFileSystemInfo> files = this.fileService.SearchDirectory(dirInfo.FullName, "*.*", SearchOptions.File,
				                                                                      SearchLocation.Recursive);
				Assert.That(files.Count(), Is.EqualTo(2));
				this.EnumerablePathEquals(files, dirInfo.FullName, new[]
				                                                   	{
				                                                   		"sub1" + seperator + "b.txt",
				                                                   		"sub2" + seperator + "a.txt",
				                                                   	});
				Transaction.Current.Rollback();
			}
		}

		[Test]
		public void Throws_exception_if_file_not_found()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				Assert.Throws<FileNotFoundException>(() => this.fileService.GetFile("asdadsdas"));
			}
		}

		[Test]
		public void Throws_exception_outside_of_the_transaction()
		{
			Assert.Throws<InvalidOperationException>(() => this.fileService.FileExists(this.assemblyFileName));
		}
	}
}