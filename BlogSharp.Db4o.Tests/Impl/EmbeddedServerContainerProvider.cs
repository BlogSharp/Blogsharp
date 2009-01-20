using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class EmbeddedServerContainerProviderTests
	{
		private const string DATABASEFILE = "database.yap";
		public EmbeddedServerContainerProviderTests()
		{
			this.objectServer = MockRepository.GenerateMock<IExtObjectServer>();
			this.objectContainerProvider = new EmbeddedServerContainerProvider(this.objectServer);
		}

		private readonly IExtObjectServer objectServer;
		private readonly IObjectContainerProvider objectContainerProvider;

		[Fact]
		public void Can_open_client_without_configuration()
		{
			this.objectContainerProvider.GetContainer();
			this.objectServer.AssertWasCalled(x=>x.OpenClient());
		}

		[Fact]
		public void Can_open_client_with_configuration()
		{
			var configuration = Db4oFactory.NewConfiguration();
			this.objectContainerProvider.GetContainer(configuration);
			this.objectServer.AssertWasCalled(x => x.OpenClient(configuration));
		}
	}
}
