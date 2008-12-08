using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Impl.Services.FileSystem;
using BlogSharp.Core.Services.FileSystem;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	public class FileServiceTests
	{
		public FileServiceTests()
		{
			this.fileService = new FileService();
			this.assemblyFile = this.GetType().Assembly.Location;
			this.assemblyDirectory = new FileInfo(this.assemblyFile).DirectoryName;
			this.fileName = new FileInfo(this.assemblyFile).Name;
		}

		private readonly IFileService fileService;
		private readonly string assemblyFile;
		private readonly string assemblyDirectory;
		private readonly string fileName;
		[Fact]
		public void Can_see_if_file_exists()
		{
			Assert.True(fileService.FileExists(assemblyFile));
		}
		[Fact]
		public void Can_see_if_directory_exists()
		{
			Assert.True(fileService.DirectoryExists(assemblyDirectory));
		}

		[Fact]
		public void Returns_correct_file_if_found()
		{
			IFile file = fileService.GetFile(this.assemblyFile);
			Assert.Equal(this.fileName, file.Name);
		}

		[Fact]
		public void Throws_exception_if_file_not_found()
		{
			Assert.Throws<FileNotFoundException>(() => fileService.GetFile(this.assemblyFile + "bah"));
		}

	}
}
