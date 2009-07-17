namespace BlogSharp.CastleExtensions.Facilities
{
	using System.Web.Mvc;
	using Castle.Core;
	using Castle.MicroKernel.Facilities;

	public class ControllerRegisterFacility : AbstractFacility
	{
		protected override void Init()
		{
			Kernel.ComponentModelCreated +=
				delegate(ComponentModel model)
					{
						if (typeof (IController).IsAssignableFrom(model.Implementation))
							model.LifestyleType = LifestyleType.Transient;
					};
		}
	}
}