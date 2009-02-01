using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using NUnit.Framework;
using Rhino.Mocks;


namespace BlogSharp.Db4o.Tests.Impl
{
	[TestFixture]
	public class EmbeddedServerContainerProviderTests
	{
		private const string DATABASEFILE = "database.yap";

		private IObjectContainerProvider objectContainerProvider;
		private IExtObjectServer objectServer;

		[SetUp]
		public void SetUp()
		{
			objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			objectContainerProvider = new EmbeddedServerContainerProvider(objectServer);
		}

		[Test]
		public void Can_open_client_without_configuration()
		{
			objectContainerProvider.GetContainer();
			objectServer.AssertWasCalled(x => x.OpenClient());
		}

		[Test]
		public void Can_open_client_with_configuration()
		{
			var configuration = Db4oFactory.NewConfiguration();
			objectContainerProvider.GetContainer(configuration);
			objectServer.AssertWasCalled(x => x.OpenClient(configuration));
		}
	}
}