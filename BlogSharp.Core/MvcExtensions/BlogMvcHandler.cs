using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.Core.MvcExtensions.ControllerFactories;

namespace BlogSharp.Core.MvcExtensions
{
	public class BlogMvcHandler : System.Web.Mvc.MvcHandler
	{

		public BlogMvcHandler(RequestContext requestContext)
			: base(requestContext)
		{
		}
		protected override void ProcessRequest(System.Web.HttpContext httpContext)
		{
			HttpContextBase iHttpContext = new HttpContextWrapper(httpContext);
			ProcessRequest(iHttpContext);
		}

		protected override void ProcessRequest(System.Web.HttpContextBase httpContext)
		{
			var factory = ControllerBuilder.Current.GetControllerFactory() as IExtendedControllerFactory;
			var controller = (ControllerBase)factory.CreateController(RequestContext, (Type)RequestContext.RouteData.Values["controller"]);
			this.ProcessRequest(controller.ControllerContext.HttpContext);
		}
	}

}
