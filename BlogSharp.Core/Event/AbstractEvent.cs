namespace BlogSharp.Core.Event
{
	public abstract class AbstractEvent<TSource> : IEvent<TSource>
	{
		/// <param name="source">The source that the event is raised from</param>
		protected AbstractEvent(TSource source)
		{
			EventSource = source;
		}

		#region IEvent<TSource> Members

		public TSource EventSource { get; set; }

		object IEvent.EventSource
		{
			get
			{
				return this.EventSource;
			}
			set
			{
				this.EventSource = (TSource)value;
			}
		}

		
		#endregion




	}
}
