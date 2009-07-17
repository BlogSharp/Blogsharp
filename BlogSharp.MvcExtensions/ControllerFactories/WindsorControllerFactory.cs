// <copyright file="WindsorControllerFactory.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.MvcExtensions.ControllerFactories
{
	using System;
	using System.Web.Mvc;
	using System.Web.Routing;
	using Castle.MicroKernel;

	/// <summary>
	/// The factory for the Windsor controllers
	/// </summary>
	public class WindsorControllerFactory : DefaultControllerFactory, IExtendedControllerFactory
	{
		/// <summary>
		/// The Windsor kernel.
		/// </summary>
		private readonly IKernel kernel;

		/// <summary>
		/// Initializes a new instance of the <see cref="WindsorControllerFactory" /> class. 
		/// </summary>
		/// <param name="kernel">The Windsor kernel.</param>
		public WindsorControllerFactory(IKernel kernel)
		{
			this.kernel = kernel;
		}

		#region IExtendedControllerFactory Members

		/// <summary>
		/// Creates a new controller.
		/// </summary>
		/// <param name="context">The context of the creation.</param>
		/// <param name="controllerType">The type of controller.</param>
		/// <returns>The created controller.</returns>
		public IController CreateController(RequestContext context, Type controllerType)
		{
			return GetControllerInstance(controllerType);
		}

		/// <summary>
		/// Releases a created controller.
		/// </summary>
		/// <param name="controller">The controller to release.</param>
		public override void ReleaseController(IController controller)
		{
			kernel.ReleaseComponent(controller);
			base.ReleaseController(controller);
		}

		#endregion

		/// <summary>
		/// Obtains a Instance of a existent controller.
		/// </summary>
		/// <param name="controllerType">The type of controller.</param>
		/// <returns>The controller.</returns>
		protected override IController GetControllerInstance(Type controllerType)
		{
			return kernel.Resolve(controllerType) as IController;
		}
	}
}