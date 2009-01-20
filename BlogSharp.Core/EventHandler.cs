using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Event;

namespace BlogSharp.Core
{
    public delegate void EventHandler<TEventArgs>(TEventArgs eventArgs);
	public interface IEventListener<TEventArgs> where TEventArgs:IEventArgs
	{
		void Handle(TEventArgs eventArgs);
	}



	public static class EventHandlerHelpers
	{
		public static void Raise<TEventArgs>(this EventHandler<TEventArgs> @event,TEventArgs eventArgs)
			where TEventArgs : IEventArgs
		{
			if(@event!=null)
				@event(eventArgs);
		}
	}
}
