using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSharp.Core.MvcExtensions.ControllerFactories
{
	public interface IExtendedControllerFactory : IControllerFactory
	{
		IController CreateController(RequestContext context, Type controllerType);
	}
}
