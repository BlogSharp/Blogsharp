using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class ResourceObjectContainerAdapterTests
	{
		private readonly ResourceObjectContainerAdapter adapter;
		private readonly IExtObjectContainer container;

		public ResourceObjectContainerAdapterTests()
		{
			container = MockRepository.GenerateMock<IExtObjectContainer>();
			adapter = new ResourceObjectContainerAdapter(container);
		}

		[Fact]
		public void Commit_calls_commit_on_container()
		{
			adapter.Commit();
			container.AssertWasCalled(x => x.Commit());
		}

		[Fact]
		public void Rollback_calls_rollback_on_container()
		{
			adapter.Rollback();
			container.Expect(x => x.Rollback());
		}
	}
}