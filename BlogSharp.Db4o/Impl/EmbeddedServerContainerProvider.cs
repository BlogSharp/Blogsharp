namespace BlogSharp.Db4o.Impl
{
	using Db4objects.Db4o.Config;
	using Db4objects.Db4o.Ext;

	public class EmbeddedServerContainerProvider : IObjectContainerProvider
	{
		private readonly IExtObjectServer objectServer;

		public EmbeddedServerContainerProvider(IExtObjectServer objectServer)
		{
			this.objectServer = objectServer;
		}

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