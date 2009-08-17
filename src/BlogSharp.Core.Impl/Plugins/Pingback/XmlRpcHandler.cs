using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Impl.Plugins.Pingback
{
	using System.Web;
	using System.Web.Routing;
	using Castle.Windsor;
	using CookComputing.XmlRpc;

	public class XmlRpcRouteHandler<THandler> : IRouteHandler where THandler : XmlRpcService
	{
		private readonly IWindsorContainer windsorContainer;

		public XmlRpcRouteHandler(IWindsorContainer windsorContainer)
		{
			this.windsorContainer = windsorContainer;
		}

		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			return this.windsorContainer.Resolve<THandler>();
		}
	}
}
