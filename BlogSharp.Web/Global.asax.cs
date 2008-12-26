using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.Web.AreaLib;

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

			RegisterRoutes(RouteTable.Routes);
		}
	}
}
