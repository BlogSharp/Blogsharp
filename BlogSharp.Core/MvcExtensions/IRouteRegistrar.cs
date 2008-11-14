using System.Web.Routing;

namespace BlogSharp.Core.MvcExtensions
{
	public interface IRouteRegistrar
	{
		void RegisterRoutes(RouteCollection routes);
		void UnRegisterRoutes(RouteCollection routes);
	}
}