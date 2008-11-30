namespace BlogSharp.Core.Event
{
	public interface IEvent
	{
		object EventSource { get; set; }
	}
	public interface IEvent<TSource>:IEvent
	{
		/// <summary>
		/// The source that the event is raised from
		/// </summary>
		new TSource EventSource { get; set; }
	}
}