using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PlugingEvents
{
	public class ApplicationStarted : AbstractEvent<IPluginService>
	{
		public ApplicationStarted(IPluginService pluginService)
			: base(pluginService)
		{
		}
	}
}