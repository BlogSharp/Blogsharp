namespace BlogSharp.Db4o.Tests
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
			objectContainer = MockRepository.GenerateMock<IExtObjectContainer>();
			objectServer.Expect(x => x.OpenClient()).Return(objectContainer);
			provider = new EmbeddedServerContainerProvider(objectServer);
		}

		#endregion

		private IObjectContainer objectContainer;
		private IExtObjectServer objectServer;
		private IObjectContainerProvider provider;

		[Test]
		public void Should_return_client_instance()
		{
			Assert.AreEqual(objectContainer, objectServer.OpenClient());
		}
	}
}