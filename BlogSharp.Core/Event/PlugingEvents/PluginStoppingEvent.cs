using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PlugingEvents
{
	public class PluginStoppingEvent : AbstractEvent<IPluginService>, ICancellableEvent
	{
		public PluginStoppingEvent(IPluginService pluginService)
			: base(pluginService)
		{
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}