namespace BlogSharp.MvcExtensions.Handlers
{
	using System;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;

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
			IExtendedControllerFactory factory = ControllerBuilder.Current.GetControllerFactory() as IExtendedControllerFactory;
			var controller = factory.CreateController(this.RequestContext,
			                                          (Type) this.RequestContext.RouteData.Values["controller"]);
			try
			{
				controller.Execute(this.RequestContext);
			}
			finally
			{
				factory.ReleaseController(controller);
			}
		}
	}
}