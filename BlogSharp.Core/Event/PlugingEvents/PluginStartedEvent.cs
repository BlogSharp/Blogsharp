using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PlugingEvents
{
	public class ApplicationStarted : AbstractEvent<IPluginService>
	{
		public ApplicationStarted(IPluginService pluginService)
			: base(pluginService)
		{

		}

	}
}