using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Impl
{
	public class EmbeddedServerContainerProvider:IObjectContainerProvider
	{
		public EmbeddedServerContainerProvider(IExtObjectServer objectServer)
		{
			this.objectServer = objectServer;
		}

		private readonly IExtObjectServer objectServer;

		#region IObjectContainerProvider Members

		public IExtObjectContainer GetContainer()
		{
			return objectServer.OpenClient() as IExtObjectContainer;
		}

		public IExtObjectContainer GetContainer(IConfiguration configuration)
		{
			return objectServer.OpenClient(configuration) as IExtObjectContainer;
		}

		#endregion
	}

	public interface IObjectContainerProvider
	{
		IExtObjectContainer GetContainer();
		IExtObjectContainer GetContainer(IConfiguration configuration);
	}
}
