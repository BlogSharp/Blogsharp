namespace BlogSharp.Core.Event
{
	public interface IEventArgs
	{
		object EventSource { get; set; }
	}
	public interface IEventArgs<TSource>:IEventArgs
	{
		/// <summary>
		/// The source that the event is raised from
		/// </summary>
		new TSource EventSource { get; set; }
	}
}