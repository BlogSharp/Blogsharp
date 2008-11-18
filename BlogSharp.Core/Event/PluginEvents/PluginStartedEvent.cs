using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class ApplicationStarted : AbstractEvent<IPluginService>
	{
		public ApplicationStarted(IPluginService pluginService)
			: base(pluginService)
		{
		}
	}
}