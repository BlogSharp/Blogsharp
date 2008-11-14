using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PlugingEvents
{
	public class PluginStartingEvent : AbstractEvent<IPluginService>, ICancellableEvent
	{
		public PluginStartingEvent(IPluginService pluginService)
			: base(pluginService)
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