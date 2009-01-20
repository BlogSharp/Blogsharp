using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Ext;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class RemoteServerContainerProviderTests:IDisposable
	{
		private const string DATABASEFILE = "database.yap";
		public RemoteServerContainerProviderTests()
		{
			this.objectServer = Db4oFactory.OpenServer(DATABASEFILE, 123).Ext();
			this.objectServer.GrantAccess("tehlike", "12345678");
			this.objectContainerProvider = new RemoteServerContainerProvider("127.0.0.1", 123, "tehlike", "12345678");
		}

		public void Dispose()
		{
			this.objectServer.Close();
			File.Delete(DATABASEFILE);
		}

		private readonly IExtObjectServer objectServer;
		private readonly IObjectContainerProvider objectContainerProvider;

		[Fact]
		public void Can_open_client_without_configuration()
		{
			IObjectContainer container = this.objectContainerProvider.GetContainer();
			Assert.NotNull(container);
		}

		[Fact]
		public void Can_open_client_with_configuration()
		{
			IConfiguration config = Db4oFactory.NewConfiguration();
			IObjectContainer container = this.objectContainerProvider.GetContainer(config);
			Assert.NotNull(container);
			Assert.Equal(config, container.Ext().Configure());
		}
	}
}
