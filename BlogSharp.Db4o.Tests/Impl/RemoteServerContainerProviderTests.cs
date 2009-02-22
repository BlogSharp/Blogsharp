namespace BlogSharp.Db4o.Tests.Impl
{
	#region usings

	using System.IO;
	using Db4o.Impl;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Config;
	using Db4objects.Db4o.Ext;
	using NUnit.Framework;

	#endregion

	[TestFixture]
	public class RemoteServerContainerProviderTests
	{
		private const string DATABASEFILE = "database.yap";
		private IObjectContainerProvider objectContainerProvider;
		private IExtObjectServer objectServer;
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			objectServer = Db4oFactory.OpenServer(DATABASEFILE, 123).Ext();
			objectServer.GrantAccess("tehlike", "12345678");
			objectContainerProvider = new RemoteServerContainerProvider("127.0.0.1", 123, "tehlike", "12345678");
		}

		[TearDown]
		public void OnTearDown()
		{
			objectServer.Close();
			File.Delete(DATABASEFILE);
		}

		#endregion

		[Test]
		public void Can_open_client_with_configuration()
		{
			IConfiguration config = Db4oFactory.NewConfiguration();
			IObjectContainer container = objectContainerProvider.GetContainer(config);
			Assert.NotNull(container);
			Assert.AreEqual(config, container.Ext().Configure());
		}

		[Test]
		public void Can_open_client_without_configuration()
		{
			IObjectContainer container = objectContainerProvider.GetContainer();
			Assert.NotNull(container);
		}
	}
}