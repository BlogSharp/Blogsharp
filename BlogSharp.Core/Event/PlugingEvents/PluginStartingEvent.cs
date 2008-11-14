using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PlugingEvents
{
	public class PluginStartingEvent : AbstractEvent<IPluginService>, ICancellableEvent
	{
		public PluginStartingEvent(IPluginService pluginService)
			: base(pluginService)
		{
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}