namespace BlogSharp.Core.Event.ApplicationEvents
{
	public class ApplicationStartingEvent : AbstractEvent<IApplication>, ICancellableEvent
	{
		public ApplicationStartingEvent(IApplication app) : base(app)
		{
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}