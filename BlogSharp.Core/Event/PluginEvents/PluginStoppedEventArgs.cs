namespace BlogSharp.Core.Event.PluginEvents
{
	using Services.Plugin;

	public class PluginStoppedEventArgs : AbstractEventArgs<IPluginService>
	{
		public PluginStoppedEventArgs(IPluginService service, IPlugin plugin)
			: base(service)
		{
			Plugin = plugin;
		}

		public IPlugin Plugin { get; set; }
	}
}