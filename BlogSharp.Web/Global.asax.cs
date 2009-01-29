using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.CastleExtensions.DependencyResolvers;
using BlogSharp.CastleExtensions.Facilities;
using BlogSharp.Core;
using BlogSharp.Core.Impl.Installers;
using BlogSharp.Core.Persistence;
using BlogSharp.Core.Web;
using BlogSharp.Core.Web.Modules;
using BlogSharp.MvcExtensions;
using BlogSharp.MvcExtensions.ControllerFactories;
using BlogSharp.Web.Controllers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Spark.Web.Mvc;
using MvcContrib.Routing;

namespace BlogSharp.Web
{
	public class MvcApplication : System.Web.HttpApplication,IContainerAccessor
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			routes.MapRoute("PostList", "post/list/{page}", new
			{
				controller = "Post",
				action = "List",
				page = 0
			});

			routes.MapRoute(
				"Default",
				"{controller}/{action}",
				new { controller = "Post", action = "Index" }  // Parameter defaults
			);
		}

		private static bool isInitialized = false;
		public override void Init()
		{
			if(isInitialized==false)
			{
				container.Register(Component.For<HttpApplication>().Instance(this));
				var modules = container.ResolveAll<IBlogSharpHttpModule>();
				foreach (var module in modules)
				{
					module.Start();
				}
				isInitialized = true;
			}

		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
			var engine = new SparkViewFactory();
			ViewEngines.Engines.Add(engine);

			container = new WindsorContainer("Configuration/castle.xml");
			container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
			container
				.Install(new DefaultComponentInstallers());
			ControllerBuilder.Current.SetControllerFactory(container.Resolve<IExtendedControllerFactory>());
			var installer = container.Resolve<IStartupInstaller>();
			installer.Execute();
		}


		#region IContainerAccessor Members

		public IWindsorContainer Container
		{
			get { return container; }
		}

		private static IWindsorContainer container;
		#endregion
	}
}
