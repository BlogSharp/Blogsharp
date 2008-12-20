using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStoppingEvent : AbstractEventArgs, ICancellableEvent
	{
		public PluginStoppingEvent(IPlugin plugin)
		{
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}