namespace BlogSharp.Core.Event.ApplicationEvents
{
	public class ApplicationStartingEventArgs : AbstractEventArgs, ICancellableEvent
	{
		public ApplicationStartingEventArgs()
		{
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}