using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStoppedEventArgs : AbstractEventArgs<IPluginService>
	{
		public PluginStoppedEventArgs(IPluginService service,IPlugin plugin)
			:base(service)
		{
		    this.Plugin = plugin;
		}

	    public IPlugin Plugin { get; set; }
	}
}