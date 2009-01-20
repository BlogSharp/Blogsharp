using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace BlogSharp.CastleExtensions.Facilities
{
	public class ControllerRegisterFacility : AbstractFacility
	{
		protected override void Init()
		{
			Kernel.ComponentModelCreated +=
				delegate(ComponentModel model)
				{
					if (typeof(IController).IsAssignableFrom(model.Implementation))
						model.LifestyleType = LifestyleType.Transient;
				};
		}
	}
}
