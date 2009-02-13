using System.Transactions;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using NUnit.Framework;
namespace BlogSharp.Db4o.Tests.Impl
{
	[TestFixture]
	public class ResourceObjectContainerAdapterTests
	{
		private ResourceObjectContainerAdapter adapter;
		private IExtObjectContainer container;

		[SetUp]
		public void SetUp()
		{
			container = MockRepository.GenerateMock<IExtObjectContainer>();
			adapter = new ResourceObjectContainerAdapter(container);
		}

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