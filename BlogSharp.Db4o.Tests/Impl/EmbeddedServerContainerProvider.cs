using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class EmbeddedServerContainerProviderTests
	{
		private const string DATABASEFILE = "database.yap";

		private readonly IObjectContainerProvider objectContainerProvider;
		private readonly IExtObjectServer objectServer;

		public EmbeddedServerContainerProviderTests()
		{
			objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			objectContainerProvider = new EmbeddedServerContainerProvider(objectServer);
		}

		[Fact]
		public void Can_open_client_without_configuration()
		{
			objectContainerProvider.GetContainer();
			objectServer.AssertWasCalled(x => x.OpenClient());
		}

		[Fact]
		public void Can_open_client_with_configuration()
		{
			var configuration = Db4oFactory.NewConfiguration();
			objectContainerProvider.GetContainer(configuration);
			objectServer.AssertWasCalled(x => x.OpenClient(configuration));
		}
	}
}