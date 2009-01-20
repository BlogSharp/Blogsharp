using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests
{
	public class EmbeddedServerContainerProviderTests
	{
		public EmbeddedServerContainerProviderTests()
		{
			this.objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			this.objectContainer = MockRepository.GenerateMock<IExtObjectContainer>();
			this.objectServer.Expect(x => x.OpenClient()).Return(this.objectContainer);
			this.provider = new EmbeddedServerContainerProvider(this.objectServer);
		}

		private readonly IObjectContainerProvider provider;
		private readonly IExtObjectServer objectServer;
		private readonly IObjectContainer objectContainer;

		[Fact]
		public void Should_return_client_instance()
		{
			Assert.Equal(this.objectContainer,objectServer.OpenClient());
		}
	}
}
