﻿using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStoppedEvent : AbstractEvent<IPluginService>
	{
		public PluginStoppedEvent(IPluginService pluginService)
			: base(pluginService)
		{
		}
	}
}