namespace BlogSharp.Core.Event
{
	public interface IEventArgs
	{
		object Source { get; }
	}

	public interface IEventArgs<TSource> : IEventArgs
	{
		/// <summary>
		/// The source that the event is raised from
		/// </summary>
		new TSource Source { get; }
	}
}