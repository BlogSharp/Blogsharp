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
        private IFileService _fileService;
        private string _root;

        #region Setup/Teardown
        [SetUp]
        public void SetUp()
        {
            if (System.IO.Directory.Exists("root"))
            {
                System.IO.Directory.Delete("root", true);
            }

            DirectoryInfo dirInfo = System.IO.Directory.CreateDirectory("root");
            this._root = dirInfo.FullName;
            DirectoryInfo dirInfo1 = dirInfo.CreateSubdirectory("sub1");
            DirectoryInfo dirInfo2 = dirInfo.CreateSubdirectory("sub2");
            dirInfo1.CreateSubdirectory("sub11");
            dirInfo2.CreateSubdirectory("sub21");
            this._fileService = new TransactionalFileService(new CastleProxyFactory());
        }

        [TearDown]
        public void TearDown()
        {
            System.IO.Directory.Delete("root", true);
        }

        #endregion

        [Test]
        public void Children_returns_children()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                IDirectory dir = this._fileService.GetDirectory(this._root);
                var children = dir.Children;

                // var pathList = new[] {"sub1", "sub2"};
                // int i = 0;
                // foreach (var info in children)
                // {
                //     Assert.That(info.Path, Is.EqualTo(Path.Combine(this.root, pathList[i++])));
                // }
            }
        }

        [Test, Ignore("Ignored for further investigation")]
        public void Parent_returns_the_correct_directory()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var dirInfo = new DirectoryInfo(this._root);
                IDirectory dir = this._fileService.GetDirectory(this._root);
                Assert.NotNull(dir.Parent);
                Assert.That(dirInfo.Name, Is.EqualTo(dir.Name));
                Assert.That(dirInfo.Parent.Name, Is.EqualTo(dir.Parent.Name));
                Assert.That(dirInfo.Parent.Parent.Name, Is.EqualTo(dir.Parent.Parent.Name));
            }
        }
    }
}