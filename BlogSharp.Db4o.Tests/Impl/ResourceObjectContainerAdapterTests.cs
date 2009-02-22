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
			this.container = MockRepository.GenerateMock<IExtObjectContainer>();
			this.adapter = new ResourceObjectContainerAdapter(this.container);
		}

		#endregion

		private ResourceObjectContainerAdapter adapter;
		private IExtObjectContainer container;

		[Test]
		public void Commit_calls_commit_on_container()
		{
			this.adapter.Commit(null);
			this.container.AssertWasCalled(x => x.Commit());
		}

		[Test]
		public void Rollback_calls_rollback_on_container()
		{
			this.adapter.Rollback(null);
			this.container.Expect(x => x.Rollback());
		}
	}
}