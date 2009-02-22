namespace BlogSharp.Core.Impl.Tests.Services.FileSystem
{
	using System.IO;
	using System.Transactions;
	using Core.Services.FileSystem;
	using Impl.Services.FileSystem;
	using Impl.Services.FileSystem.Castle;
	using NUnit.Framework;

	[TestFixture]
	public class DirectoryTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			DirectoryInfo dirInfo = System.IO.Directory.CreateDirectory("root");
			this.root = dirInfo.FullName;
			DirectoryInfo dirInfo1 = dirInfo.CreateSubdirectory("sub1");
			DirectoryInfo dirInfo2 = dirInfo.CreateSubdirectory("sub2");
			dirInfo1.CreateSubdirectory("sub11");
			dirInfo2.CreateSubdirectory("sub21");
			this.fileService = new TransactionalFileService(new CastleProxyFactory());
		}

		[TearDown]
		public void TearDown()
		{
			System.IO.Directory.Delete("root", true);
		}

		#endregion

		private IFileService fileService;
		private string root;

		[Test]
		public void Children_returns_children()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				IDirectory dir = this.fileService.GetDirectory(this.root);
				var children = dir.Children;
				var pathList = new[] {"sub1", "sub2"};
				int i = 0;
				foreach (var info in children)
				{
					Assert.That(info.Path, Is.EqualTo(Path.Combine(this.root, pathList[i++])));
				}
			}
		}

		[Test]
		public void Parent_returns_the_correct_directory()
		{
			using (TransactionScope scope = new TransactionScope())
			{
				var dirInfo = new DirectoryInfo(this.root);
				IDirectory dir = this.fileService.GetDirectory(this.root);
				Assert.NotNull(dir.Parent);
				Assert.That(dirInfo.Name, Is.EqualTo(dir.Name));
				Assert.That(dirInfo.Parent.Name, Is.EqualTo(dir.Parent.Name));
				Assert.That(dirInfo.Parent.Parent.Name, Is.EqualTo(dir.Parent.Parent.Name));
			}
		}
	}
}