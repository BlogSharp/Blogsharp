using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.Core.MvcExtensions.ControllerFactories;

namespace BlogSharp.Core.MvcExtensions
{
	public class BlogMvcHandler : MvcHandler
	{
		public BlogMvcHandler(RequestContext requestContext)
			: base(requestContext)
		{
		}

		protected override void ProcessRequest(HttpContext httpContext)
		{
			HttpContextBase iHttpContext = new HttpContextWrapper(httpContext);
			ProcessRequest(iHttpContext);
		}

		protected override void ProcessRequest(HttpContextBase httpContext)
		{
			var factory = ControllerBuilder.Current.GetControllerFactory() as IExtendedControllerFactory;
			var controller =
				(ControllerBase) factory.CreateController(RequestContext, (Type) RequestContext.RouteData.Values["controller"]);
			ProcessRequest(controller.ControllerContext.HttpContext);
		}
	}
}