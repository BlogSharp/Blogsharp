using System;
using System.IO;
using System.Transactions;
using BlogSharp.Core.Impl.Services.FileSystem;
using BlogSharp.Core.Impl.Services.FileSystem.Castle;
using BlogSharp.Core.Services.FileSystem;
using NUnit.Framework;

namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	[TestFixture]
	public class DirectoryTests
	{
		private IFileService fileService;
		private string root;

		[SetUp]
		public void SetUp()
		{
			DirectoryInfo dirInfo = System.IO.Directory.CreateDirectory("root");
			root = dirInfo.FullName;
			DirectoryInfo dirInfo1 = dirInfo.CreateSubdirectory("sub1");
			DirectoryInfo dirInfo2 = dirInfo.CreateSubdirectory("sub2");
			dirInfo1.CreateSubdirectory("sub11");
			dirInfo2.CreateSubdirectory("sub21");
			fileService = new TransactionalFileService(new CastleProxyFactory());
		}

		[TearDown]
		public void TearDown()
		{
			System.IO.Directory.Delete("root", true);
		}

		[Test]
		public void Parent_returns_the_correct_directory()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				var dirInfo = new DirectoryInfo(root);
				IDirectory dir = fileService.GetDirectory(root);
				Assert.NotNull(dir.Parent);
				Assert.That(dirInfo.Name,Is.EqualTo(dir.Name));
				Assert.That(dirInfo.Parent.Name, Is.EqualTo(dir.Parent.Name));
				Assert.That(dirInfo.Parent.Parent.Name,Is.EqualTo(dir.Parent.Parent.Name));
			}
		}

		[Test]
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
					Assert.That(info.Path,Is.EqualTo(Path.Combine(root, pathList[i++])));
				}
			}
		}
	}
}