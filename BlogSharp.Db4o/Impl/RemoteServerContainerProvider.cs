namespace BlogSharp.Db4o.Impl
{
	using Db4objects.Db4o;
	using Db4objects.Db4o.Config;
	using Db4objects.Db4o.Ext;

	public class RemoteServerContainerProvider : IObjectContainerProvider
	{
		public RemoteServerContainerProvider(string host, int port, string username, string password)
		{
			this.Host = host;
			this.Port = port;
			this.Username = username;
			this.Password = password;
		}

		public string Host { get; set; }
		public int Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		#region IObjectContainerProvider Members

		public virtual IExtObjectContainer GetContainer(IConfiguration configuration)
		{
			return Db4oFactory.OpenClient(configuration, this.Host, this.Port, this.Username, this.Password).Ext();
		}

		public virtual IExtObjectContainer GetContainer()
		{
			return Db4oFactory.OpenClient(this.Host, this.Port, this.Username, this.Password).Ext();
		}

		#endregion
	}
}