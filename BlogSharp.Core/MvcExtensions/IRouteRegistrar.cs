using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace BlogSharp.Core.MvcExtensions
{
	public interface IRouteRegistrar
	{
		void RegisterRoutes(RouteCollection routes);
		void UnRegisterRoutes(RouteCollection routes);
	}
}
