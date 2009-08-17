namespace BlogSharp.Core.Event.PluginEvents
{
	using System;
	using Services.Plugin;

	public class PluginStartedEventArgs : AbstractEventArgs<IPluginService>
	{
		public PluginStartedEventArgs(IPluginService service)
			: base(service)
		{
			throw new NotImplementedException();
		}
	}
}