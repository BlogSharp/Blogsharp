using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace BlogSharp.Core
{
	public static class DI
	{
		public static void SetContainer(IWindsorContainer container)
		{
			Container = container;
		}
		public static IWindsorContainer Container { get; private set; }
	}
}
