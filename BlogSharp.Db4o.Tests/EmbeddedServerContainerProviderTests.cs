using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests
{
	public class EmbeddedServerContainerProviderTests
	{
		private readonly IObjectContainer objectContainer;
		private readonly IExtObjectServer objectServer;
		private readonly IObjectContainerProvider provider;

		public EmbeddedServerContainerProviderTests()
		{
			objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			objectContainer = MockRepository.GenerateMock<IExtObjectContainer>();
			objectServer.Expect(x => x.OpenClient()).Return(objectContainer);
			provider = new EmbeddedServerContainerProvider(objectServer);
		}

		[Fact]
		public void Should_return_client_instance()
		{
			Assert.Equal(objectContainer, objectServer.OpenClient());
		}
	}
}