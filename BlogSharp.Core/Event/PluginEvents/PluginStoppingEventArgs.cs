using System;
using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStoppingEventArgs : AbstractEventArgs<IPluginService>, ICancellableEvent
	{
		public PluginStoppingEventArgs(IPluginService pluginService, IPlugin plugin)
			: base(pluginService)
		{
			throw new NotImplementedException();
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}