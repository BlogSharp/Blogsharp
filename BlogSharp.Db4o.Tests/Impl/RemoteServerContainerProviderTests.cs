using System;
using System.IO;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Ext;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class RemoteServerContainerProviderTests : IDisposable
	{
		private const string DATABASEFILE = "database.yap";
		private readonly IObjectContainerProvider objectContainerProvider;
		private readonly IExtObjectServer objectServer;

		public RemoteServerContainerProviderTests()
		{
			objectServer = Db4oFactory.OpenServer(DATABASEFILE, 123).Ext();
			objectServer.GrantAccess("tehlike", "12345678");
			objectContainerProvider = new RemoteServerContainerProvider("127.0.0.1", 123, "tehlike", "12345678");
		}

		#region IDisposable Members

		public void Dispose()
		{
			objectServer.Close();
			File.Delete(DATABASEFILE);
		}

		#endregion

		[Fact]
		public void Can_open_client_without_configuration()
		{
			IObjectContainer container = objectContainerProvider.GetContainer();
			Assert.NotNull(container);
		}

		[Fact]
		public void Can_open_client_with_configuration()
		{
			IConfiguration config = Db4oFactory.NewConfiguration();
			IObjectContainer container = objectContainerProvider.GetContainer(config);
			Assert.NotNull(container);
			Assert.Equal(config, container.Ext().Configure());
		}
	}
}