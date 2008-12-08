using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;
using Xunit;
using File=BlogSharp.Core.Impl.Services.FileSystem.File;

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	public class FileTests:IDisposable
	{
		public FileTests()
		{
			string folderPath = this.GetType().Assembly.Location;
			var directory = new FileInfo(folderPath).DirectoryName;
			testFilePath=Path.Combine(directory, "test.txt");
			System.IO.File.Delete(this.testFilePath);
			FileInfo fileInfo = new FileInfo(testFilePath);
			using(var s=fileInfo.OpenWrite())
			{
				using(var sw=new StreamWriter(s))
				{
					sw.Write("blah");
					sw.Close();
				}
				s.Close();
			}
			this.file = new File(fileInfo);
			
		}


		#region IDisposable Members

		public void Dispose()
		{
			System.IO.File.Delete(this.testFilePath);
		}

		#endregion



		private string testFilePath;
		private IFile file;


		[Fact]
		public void Open_read_can_return_stream_with_file_content()
		{
			string data;
			using(var fileStream=file.OpenRead())
			{
				using(var sr=new StreamReader(fileStream))
				{
					data=sr.ReadLine();
				}
			}
			Assert.Equal("blah", data);
		}

		[Fact]
		public void Open_write_returns_stream_to_be_written()
		{
			string data;
			using(var fileStream=file.OpenWrite())
			{
				using(var sr=new StreamWriter(fileStream))
				{
					sr.Write("blah2");
					sr.Close();
				}
				fileStream.Close();
			}
			using (var fileStream = file.OpenRead())
			{
				using (var sr = new StreamReader(fileStream))
				{
					data = sr.ReadLine();
				}
			}
			Assert.Equal("blah2", data);
		}

	}
}
