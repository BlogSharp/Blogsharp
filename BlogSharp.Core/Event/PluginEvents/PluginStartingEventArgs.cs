using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStartingEventArgs : AbstractEventArgs, ICancellableEvent
	{
		public PluginStartingEventArgs(IPlugin plugin)
		{

		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}