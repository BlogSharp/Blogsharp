using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.CastleExtensions.DependencyResolvers;
using BlogSharp.Core.Impl.Installers;
using BlogSharp.Core.Web.Modules;
using BlogSharp.Db4o;
using BlogSharp.MvcExtensions;
using BlogSharp.Web.Controllers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MvcContrib.Routing;
using Spark.Web.Mvc;

namespace BlogSharp.Web
{
	public class MvcApplication : HttpApplication, IContainerAccessor
	{
		private static IWindsorContainer container;

		#region IContainerAccessor Members

		public IWindsorContainer Container
		{
			get { return container; }
		}

		#endregion

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{resource}.ico");
			MvcRoute.MappUrl("post/list/{page}")
				.ToDefaultAction<PostController>(x => x.List(0))
				.AddWithName("PostList", routes);
			MvcRoute.MappUrl("post/read/{friendlyTitle}")
				.ToDefaultAction<PostController>(x => x.Read("friendlyTitle"))
				.AddWithName("PostRead", routes);
			MvcRoute.MappUrl("{controller}/{action}")
				.ToDefaultAction<PostController>(x => x.List(0))
				.AddWithName("Default", routes);
		}


		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
			var engine = new SparkViewFactory();
			ViewEngines.Engines.Add(engine);

			container = new WindsorContainer("Configuration/castle.xml");
			container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
			container.Install(new DefaultComponentInstallers());
			ControllerBuilder.Current.SetControllerFactory(container.Resolve<IExtendedControllerFactory>());
		}

		public override void Init()
		{
			var modules = container.ResolveAll<IBlogSharpHttpModule>();
			foreach (var module in modules)
			{
				module.Init(this);
			}
		}
	}
}