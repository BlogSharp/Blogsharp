namespace BlogSharp.Core.Event.ApplicationEvents
{
	public class ApplicationStartingEventArgs : AbstractEventArgs, ICancellableEvent
	{
		public ApplicationStartingEventArgs():base(null)
		{
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}