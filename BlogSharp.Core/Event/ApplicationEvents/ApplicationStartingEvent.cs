using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event.ApplicationEvents
{
	public class ApplicationStartingEvent:AbstractEvent<IApplication>,ICancellableEvent
	{
		public ApplicationStartingEvent(IApplication app):base(app)
		{
			
		}


		#region ICancellableEvent<IApplication> Members

		public bool Cancel
		{
			get; set;
		}

		#endregion
	}
}
