namespace BlogSharp.MvcExtensions
{
	using System;
	using System.Web.Mvc;
	using System.Web.Routing;

	public interface IExtendedControllerFactory : IControllerFactory
	{
		IController CreateController(RequestContext context, Type controllerType);
	}
}