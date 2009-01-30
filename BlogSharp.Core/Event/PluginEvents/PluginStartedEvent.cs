using System;
using BlogSharp.Core.Services.Plugin;

namespace BlogSharp.Core.Event.PluginEvents
{
	public class PluginStartedEventArgs : AbstractEventArgs<IPluginService>
	{
		public PluginStartedEventArgs(IPluginService service)
			: base(service)
		{
			throw new NotImplementedException();
		}
	}
}