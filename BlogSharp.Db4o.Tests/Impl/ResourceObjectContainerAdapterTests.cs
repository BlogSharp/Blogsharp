namespace BlogSharp.Db4o.Tests.Impl
{
	#region usings

	using Db4objects.Db4o.Ext;
	using NUnit.Framework;
	using Rhino.Mocks;

	#endregion

	[TestFixture]
	public class ResourceObjectContainerAdapterTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			container = MockRepository.GenerateMock<IExtObjectContainer>();
			adapter = new ResourceObjectContainerAdapter(container);
		}

		#endregion

		private ResourceObjectContainerAdapter adapter;
		private IExtObjectContainer container;

		[Test]
		public void Commit_calls_commit_on_container()
		{
			adapter.Commit(null);
			container.AssertWasCalled(x => x.Commit());
		}

		[Test]
		public void Rollback_calls_rollback_on_container()
		{
			adapter.Rollback(null);
			container.Expect(x => x.Rollback());
		}
	}
}