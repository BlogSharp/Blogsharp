using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace BlogSharp.MvcExtensions.ControllerFactories
{
	public class WindsorControllerFactory:DefaultControllerFactory,IExtendedControllerFactory
	{
		public WindsorControllerFactory(IKernel kernel)
		{
			this.kernel = kernel;
		}

		private readonly IKernel kernel;
		#region IExtendedControllerFactory Members

		public IController CreateController(System.Web.Routing.RequestContext context, Type controllerType)
		{
			return this.GetControllerInstance(controllerType);
		}
		protected override IController GetControllerInstance(Type controllerType)
		{
			return kernel.Resolve(controllerType) as IController;
		}
		public override void ReleaseController(IController controller)
		{
			kernel.ReleaseComponent(controller);
			base.ReleaseController(controller);
		}
		#endregion
	}
}
