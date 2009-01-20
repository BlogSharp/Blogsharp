using System;
using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStartingEventArgs : AbstractEventArgs<IPluginService>, ICancellableEvent
	{
		public PluginStartingEventArgs(IPluginService service,IPlugin plugin)
			:base(service)
		{
			throw new NotImplementedException();
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}