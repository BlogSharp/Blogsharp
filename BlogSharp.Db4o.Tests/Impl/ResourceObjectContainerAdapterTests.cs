using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class ResourceObjectContainerAdapterTests
	{
		public ResourceObjectContainerAdapterTests()
		{
			this.container = MockRepository.GenerateMock<IExtObjectContainer>();
			this.adapter = new ResourceObjectContainerAdapter(container);
		}

		private readonly IExtObjectContainer container;
		private readonly ResourceObjectContainerAdapter adapter;
		
		[Fact]
		public void Commit_calls_commit_on_container()
		{
			this.adapter.Commit();
			this.container.AssertWasCalled(x=>x.Commit());
		}

		[Fact]
		public void Rollback_calls_rollback_on_container()
		{
			this.adapter.Rollback();
			this.container.Expect(x => x.Rollback());
		}
	}
}
