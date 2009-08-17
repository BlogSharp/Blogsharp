namespace BlogSharp.Core.Event
{
	public interface IEventListener<TEvent> where TEvent : IEventArgs
	{
		void Handle(TEvent @event);
	}
}