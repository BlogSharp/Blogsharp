namespace BlogSharp.MvcExtensions.Handlers
{
	using System.Web.Routing;

	public class BlogMvcRouteHandler : System.Web.Mvc.MvcRouteHandler
	{
		protected override System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var controller = requestContext.RouteData.Values["controller"];
			return new BlogMvcHandler(requestContext);
		}
	}
}