using System.Web.Routing;
using System.Web.Mvc;
using System;

namespace BlogSharp.MvcExtensions.Areas
{
	public static class AreaRouteHelper {
		public static void MapAreas(this RouteCollection routes, string url, string rootNamespace, string[] areas) {
			Array.ForEach(areas, area => {
			                             	Route route = new Route("{area}/" + url, new MvcRouteHandler());
			                             	route.Constraints = new RouteValueDictionary(new { area });
			                             	string areaNamespace = rootNamespace + ".Areas." + area + ".Controllers";
			                             	route.DataTokens = new RouteValueDictionary(new { namespaces = new[] { areaNamespace } });
			                             	route.Defaults = new RouteValueDictionary(new { action = "Index", controller = "Home", id = "" });
			                             	routes.Add(route);
			});
		}

		public static void MapRootArea(this RouteCollection routes, string url, string rootNamespace, object defaults) {
			Route route = new Route(url, new MvcRouteHandler());
			route.DataTokens = new RouteValueDictionary(new { namespaces = new[] { rootNamespace + ".Controllers" } });
			route.Defaults = new RouteValueDictionary(new { area="root", action = "Index", controller = "Home", id = "" });
			routes.Add(route);
		}
	}
}