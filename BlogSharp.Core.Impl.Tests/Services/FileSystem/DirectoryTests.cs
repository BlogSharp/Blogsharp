using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;
using Xunit;
using Directory=BlogSharp.Core.Impl.Services.FileSystem.Directory;

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	public class DirectoryTests
	{
		public DirectoryTests()
		{
			string assemblyPath = this.GetType().Assembly.Location;
			var directory = new System.IO.FileInfo(assemblyPath).Directory;
			dirInfo = directory;
			this.directory = new Directory(dirInfo);
		}

		private readonly DirectoryInfo dirInfo;
		private readonly IDirectory directory;

		[Fact]
		public void Parent_returns_the_correct_directory()
		{
			Assert.NotNull(directory.Parent);
			Assert.Equal(dirInfo.Parent.Name,directory.Parent.Name);
		}

		[Fact]
		public void Name_is_the_name_of_the_directory()
		{
			Assert.Equal(dirInfo.Name,directory.Name);
		}

		[Fact]
		public void CreateFile_creates_file_under_current_directory()
		{
			File.Delete(Path.Combine(directory.Path,"bah"));
			IFile file = directory.CreateFile("bah");
			Assert.Equal(file.Parent.Name, directory.Name);
			File.Delete(file.Path);
		}


		[Fact]
		public void CreateDirectory_creates_directory_under_current_directory()
		{
			try
			{
				System.IO.Directory.Delete(Path.Combine(directory.Path, "bah"));
			}
			catch
			{
				
			}
			IDirectory dir = directory.CreateDirectory("bah");
			Assert.Equal(dir.Parent.Name, directory.Name);
			System.IO.Directory.Delete(dir.Path,true);
		}
	}
}
