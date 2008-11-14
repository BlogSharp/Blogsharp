using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSharp.Core.MvcExtensions.ControllerFactories
{
	public interface IExtendedControllerFactory : IControllerFactory
	{
		IController CreateController(RequestContext context, Type controllerType);
	}
}