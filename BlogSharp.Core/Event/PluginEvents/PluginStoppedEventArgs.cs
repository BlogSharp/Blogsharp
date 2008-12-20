using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStoppedEventArgs : AbstractEventArgs
	{
		public PluginStoppedEventArgs(IPlugin plugin)
		{
		    this.Plugin = plugin;
		}

	    public IPlugin Plugin { get; set; }
	}
}