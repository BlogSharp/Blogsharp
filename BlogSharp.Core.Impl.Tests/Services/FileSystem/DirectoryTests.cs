using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;
using BlogSharp.Core.Impl.Services.FileSystem;
using BlogSharp.Core.Impl.Services.FileSystem.Castle;
using BlogSharp.Core.Services.FileSystem;
using Xunit;
using Directory=BlogSharp.Core.Impl.Services.FileSystem.Directory;

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	public class DirectoryTests:IDisposable
	{
		public DirectoryTests()
		{
			DirectoryInfo dirInfo=System.IO.Directory.CreateDirectory("root");
			root = dirInfo.FullName;
			DirectoryInfo dirInfo1 = dirInfo.CreateSubdirectory("sub1");
			DirectoryInfo dirInfo2 = dirInfo.CreateSubdirectory("sub2");
			dirInfo1.CreateSubdirectory("sub11");
			dirInfo2.CreateSubdirectory("sub21");
			this.fileService = new TransactionalFileService(new CastleProxyFactory());
		}

		private string root;
		public void Dispose()
		{
			System.IO.Directory.Delete("root",true);
		}


		private readonly IFileService fileService;
		[Fact]
		public void Parent_returns_the_correct_directory()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				var dirInfo = new DirectoryInfo(root);
				IDirectory dir = fileService.GetDirectory(root);
				Assert.NotNull(dir.Parent);
				Assert.Equal(dir.Name, dirInfo.Name);
				Assert.Equal(dir.Parent.Name, dirInfo.Parent.Name);
				Assert.Equal(dir.Parent.Parent.Name, dirInfo.Parent.Parent.Name);
			}
		}
		[Fact]
		public void Children_returns_children()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				IDirectory dir = fileService.GetDirectory(root);
				var children = dir.Children;
				var pathList = new[] {"sub1", "sub2"};
				int i = 0;
				foreach (var info in children)
				{
					Assert.Equal(Path.Combine(root, pathList[i++]), info.Path);

				}
			}
		}

	}
}
