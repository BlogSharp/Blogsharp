using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.Core.Impl.Installers;
using BlogSharp.MvcExtensions;
using BlogSharp.MvcExtensions.Areas;
using BlogSharp.MvcExtensions.ControllerFactories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BlogSharp.Web
{
	public class MvcApplication : System.Web.HttpApplication,IContainerAccessor
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapAreas("{controller}/{action}/{id}",
				"BlogSharp.Web",
				new[] { "Admin" });

			routes.MapRootArea("{controller}/{action}/{id}",
				"BlogSharp.Web",
				new { controller = "Home", action = "Index", id = "" });

			//RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

		}

		protected void Application_Start()
		{
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new AreaViewEngine());

			RegisterRoutes(RouteTable.Routes);

			container = new WindsorContainer("Configuration/castle.xml");
			container.Register(Component.For<IExtendedControllerFactory>().ImplementedBy<WindsorControllerFactory>());
			container.Install(new DefaultComponentInstallers());
			container.Register(AllTypes.Of<IController>().FromAssemblyNamed("BlogSharp.Web"));
			ControllerBuilder.Current.SetControllerFactory(container.Resolve<IExtendedControllerFactory>());
		}

		#region IContainerAccessor Members

		public IWindsorContainer Container
		{
			get { return container; }
		}

		private IWindsorContainer container;
		#endregion
	}
}
