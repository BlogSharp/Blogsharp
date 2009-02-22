namespace BlogSharp.Core
{
	using Event;

	public delegate void EventHandler<TEventArgs>(TEventArgs eventArgs);

	public interface IEventListener<TEventArgs> where TEventArgs : IEventArgs
	{
		void Handle(TEventArgs eventArgs);
	}


	public static class EventHandlerHelpers
	{
		public static void Raise<TEventArgs>(this EventHandler<TEventArgs> @event, TEventArgs eventArgs)
			where TEventArgs : IEventArgs
		{
			if (@event != null)
				@event(eventArgs);
		}
	}
}