using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using NUnit.Framework;

namespace BlogSharp.Db4o.Tests
{
	[TestFixture]
	public class EmbeddedServerContainerProviderTests
	{
		private IObjectContainer objectContainer;
		private IExtObjectServer objectServer;
		private IObjectContainerProvider provider;

		[SetUp]
		public void SetUp()
		{
			objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			objectContainer = MockRepository.GenerateMock<IExtObjectContainer>();
			objectServer.Expect(x => x.OpenClient()).Return(objectContainer);
			provider = new EmbeddedServerContainerProvider(objectServer);
		}

		[Test]
		public void Should_return_client_instance()
		{
			Assert.AreEqual(objectContainer, objectServer.OpenClient());
		}
	}
}