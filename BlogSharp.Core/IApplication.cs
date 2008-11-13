using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace BlogSharp.Core
{
	public interface IApplication
	{
		IWindsorContainer Resolver { get; }

	}
}
