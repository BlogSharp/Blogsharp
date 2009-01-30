using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSharp.MvcExtensions
{
	public interface IExtendedControllerFactory : IControllerFactory
	{
		IController CreateController(RequestContext context, Type controllerType);
	}
}