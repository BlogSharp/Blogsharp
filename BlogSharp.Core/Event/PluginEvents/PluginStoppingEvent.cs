using System;
using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStoppingEvent : AbstractEventArgs<IPluginService>, ICancellableEvent
	{
		public PluginStoppingEvent(IPluginService pluginService, IPlugin plugin)
			:base(pluginService)
		{
			throw new NotImplementedException();
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}