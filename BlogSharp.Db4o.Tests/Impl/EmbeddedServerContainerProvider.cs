namespace BlogSharp.Db4o.Tests.Impl
{
	using Db4o.Impl;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class EmbeddedServerContainerProviderTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			objectContainerProvider = new EmbeddedServerContainerProvider(objectServer);
		}

		#endregion

		private const string DATABASEFILE = "database.yap";

		private IObjectContainerProvider objectContainerProvider;
		private IExtObjectServer objectServer;

		[Test]
		public void Can_open_client_with_configuration()
		{
			var configuration = Db4oFactory.NewConfiguration();
			objectContainerProvider.GetContainer(configuration);
			objectServer.AssertWasCalled(x => x.OpenClient(configuration));
		}

		[Test]
		public void Can_open_client_without_configuration()
		{
			objectContainerProvider.GetContainer();
			objectServer.AssertWasCalled(x => x.OpenClient());
		}
	}
}