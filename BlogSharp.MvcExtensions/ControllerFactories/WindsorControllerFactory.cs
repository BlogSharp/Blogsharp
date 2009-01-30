﻿using System;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace BlogSharp.MvcExtensions.ControllerFactories
{
	public class WindsorControllerFactory : DefaultControllerFactory, IExtendedControllerFactory
	{
		private readonly IKernel kernel;

		public WindsorControllerFactory(IKernel kernel)
		{
			this.kernel = kernel;
		}

		#region IExtendedControllerFactory Members

		public IController CreateController(System.Web.Routing.RequestContext context, Type controllerType)
		{
			return GetControllerInstance(controllerType);
		}

		public override void ReleaseController(IController controller)
		{
			kernel.ReleaseComponent(controller);
			base.ReleaseController(controller);
		}

		#endregion

		protected override IController GetControllerInstance(Type controllerType)
		{
			return kernel.Resolve(controllerType) as IController;
		}
	}
}