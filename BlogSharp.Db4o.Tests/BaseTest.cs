namespace BlogSharp.Db4o.Tests
{
	using System.IO;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Config;
	using Db4objects.Db4o.Ext;
	using NUnit.Framework;

	public class BaseTest
	{
		protected const string DB4O_FILE_NAME = "db4o.yap";
		protected IExtObjectContainer objectContainer;
		protected TestObjectContainerManager objectContainerManager;

		[SetUp]
		public virtual void SetUp()
		{
			File.Delete(DB4O_FILE_NAME);
			IConfiguration configuration = Db4oFactory.NewConfiguration();
			this.objectContainer = Db4oFactory.OpenFile(configuration, DB4O_FILE_NAME).Ext();
			this.objectContainerManager = new TestObjectContainerManager(this.objectContainer);
		}

		[TearDown]
		public virtual void TearDown()
		{
			this.OnTearDown();
			this.objectContainer.Close();
			this.objectContainer.Dispose();

			File.Delete(DB4O_FILE_NAME);
		}

		public virtual void OnTearDown()
		{
		}
	}
}