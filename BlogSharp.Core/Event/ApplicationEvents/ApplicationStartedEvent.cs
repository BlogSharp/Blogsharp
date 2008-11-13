using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event.ApplicationEvents
{
	public class ApplicationStarted : AbstractEvent<IApplication>
	{
		public ApplicationStarted(IApplication app)
			: base(app)
		{

		}

	}
}
