namespace BlogSharp.Db4o
{
	using System;
	using System.IO;
	using Castle.Core.Configuration;
	using Castle.MicroKernel.Facilities;
	using Castle.MicroKernel.Registration;
	using Core.Web.Modules;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;
	using Impl;

	public class Db4oFacility : AbstractFacility
	{
		private Action disposeAction = delegate { };

		protected override void Init()
		{
			Kernel.Register(Component.For<IObjectContainerWrapper>()
			                	.ImplementedBy<CastleObjectContainerWrapper>())
				.Register(Component.For<IObjectServerConfigurationBuilder>()
				          	.ImplementedBy<DefaultConfigurationBuilder>())
				.Register(Component.For<IBlogSharpHttpModule>().ImplementedBy<Db4oHttpModule>());
			ConfigureFacility();
		}

		private static void AssertNullOrEmpty(string configVal, string paramName, string message)
		{
			if (string.IsNullOrEmpty(configVal))
				throw new ArgumentNullException(paramName, message);
		}

		protected virtual void ConfigureFacility()
		{
			bool firstFactory = true;

			Kernel.Register(Component.For<IObjectContainerManager>().ImplementedBy<DefaultSessionManager>());
			Kernel.Register(Component.For<IObjectContainerProviderProvider>().ImplementedBy<DefaultContainerProviderProvider>());
			string store = FacilityConfig.Attributes["store"];
			Kernel.Register(Component.For<IObjectContainerStore>().ImplementedBy(Type.GetType(store)));
			foreach (IConfiguration factoryConfig in FacilityConfig.Children)
			{
				if (!factoryConfig.Name.Equals("objectContainer"))
				{
					String message = "Unexpected node " + factoryConfig.Name;
					throw new ArgumentException(message);
				}
				ConfigureObjectServers(factoryConfig, firstFactory);
				firstFactory = false;
			}
		}

		protected virtual void ConfigureObjectServers(IConfiguration config, bool firstServer)
		{
			var providerProvider = Kernel.Resolve<IObjectContainerProviderProvider>();

			string configBuilder = config.Attributes["configurationBuilder"];
			string id = config.Attributes["id"];
			string mode = config.Attributes["mode"];
			string alias = config.Attributes["alias"];
			if (firstServer)
				alias = Constants.DefaultAlias;

			IObjectServerConfigurationBuilder configurationBuilder;
			if (!string.IsNullOrEmpty(configBuilder))
			{
				Type t = Type.GetType(configBuilder);
				Kernel.Register(
					Component.For(typeof (IObjectServerConfigurationBuilder)).ImplementedBy(t).Named(string.Format(
					                                                                                 	"{0}.configBuilder", id)));
				configurationBuilder = Kernel.Resolve<IObjectServerConfigurationBuilder>(string.Format("{0}.configBuilder", id));
			}
			else
				configurationBuilder = Kernel.Resolve<IObjectServerConfigurationBuilder>();

			AssertNullOrEmpty(id, "id",
			                  @"You must provide a valid 'id' attribute for the 'objectContainer' node. 
										This id is used as key for the ISessionFactory component registered on the container");
			AssertNullOrEmpty(alias, "alias",
			                  @"You must provide a valid 'alias' attribute for the 'objectContainer' node. 
													This id is used to obtain the ISession implementation from the SessionManager");
			AssertNullOrEmpty(mode, "mode", "You must set a ObjectContainer mode");

			Db4oMode modeEnum;
			try
			{
				modeEnum = (Db4oMode) Enum.Parse(typeof (Db4oMode), mode);
			}
			finally
			{
			}
			Db4objects.Db4o.Config.IConfiguration cfg = configurationBuilder.GetConfiguration(config);
			Kernel.AddComponentInstance(String.Format("{0}.cfg", id), cfg);
			string providerName = string.Format("db4oprovider_{0}", id);
			switch (modeEnum)
			{
				case Db4oMode.RemoteServer:
					{
						string username = config.Attributes["userName"];
						string password = config.Attributes["password"];
						string host = config.Attributes["host"];
						int port = int.Parse(config.Attributes["port"]);
						Kernel.Register(Component.For<IObjectContainerProvider>()
						                	.Named(providerName)
						                	.ImplementedBy<RemoteServerContainerProvider>()
						                	.DependsOn(new {host, username, password, port}));
					}
					break;

				case Db4oMode.EmbeddedServer:
					{
						string path = config.Attributes["path"];
						path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
						string serverName = string.Format("db4oserver_{0}", alias);
						var objectServer = Db4oFactory.OpenServer(path, 0).Ext();
						disposeAction += () => objectServer.Ext().Close();
						Kernel.Register(Component.For<IExtObjectServer>()
						                	.Forward<IObjectServer>()
						                	.Named(serverName)
						                	.Instance(objectServer))
							.Register(Component.For<IObjectContainerProvider>()
							          	.Named(providerName)
							          	.ImplementedBy<EmbeddedServerContainerProvider>()
							          	.DependsOn(new {objectServer}));
					}
					break;
			}
			providerProvider.AddProvider(alias, Kernel.Resolve<IObjectContainerProvider>(providerName));
		}

		public override void Dispose()
		{
			disposeAction();
			base.Dispose();
		}
	}
}