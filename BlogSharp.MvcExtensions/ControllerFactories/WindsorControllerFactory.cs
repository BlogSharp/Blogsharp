namespace BlogSharp.MvcExtensions.ControllerFactories
{
	using System;
	using System.Web.Mvc;
	using Castle.MicroKernel;

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
			return this.GetControllerInstance(controllerType);
		}

		public override void ReleaseController(IController controller)
		{
			this.kernel.ReleaseComponent(controller);
			base.ReleaseController(controller);
		}

		#endregion

		protected override IController GetControllerInstance(Type controllerType)
		{
			return this.kernel.Resolve(controllerType) as IController;
		}
	}
}