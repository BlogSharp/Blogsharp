using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.Core;
using BlogSharp.Core.Impl.Installers;
using BlogSharp.MvcExtensions.Areas;
using Castle.Windsor;

namespace BlogSharp.Web
{
	public class MvcApplication : System.Web.HttpApplication
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

			IWindsorContainer container = new WindsorContainer();
			container.Install(new ComponentInstaller());
			DI.SetContainer(container); 

			RegisterRoutes(RouteTable.Routes);
		}
	}
}
