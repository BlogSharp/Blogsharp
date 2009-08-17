namespace BlogSharp.Core.Event.PluginEvents
{
	using System;
	using Services.Plugin;

	public class PluginStartingEventArgs : AbstractEventArgs<IPluginService>, ICancellableEvent
	{
		public PluginStartingEventArgs(IPluginService service, IPlugin plugin)
			: base(service)
		{
			throw new NotImplementedException();
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}