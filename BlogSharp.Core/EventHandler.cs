using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Event;

namespace BlogSharp.Core
{
    public delegate void EventHandler<TSource,TEventArgs>(TSource source,TEventArgs eventArgs);
	public interface IEventListener<TSource,TEventArgs> where TEventArgs:AbstractEventArgs
	{
		void Handle(TSource source, TEventArgs eventArgs);
	}



	public static class EventHandlerHelpers
	{
		public static void Raise<TSource,TEventArgs>(this EventHandler<TSource,TEventArgs> @event,TSource source,TEventArgs eventArgs)
		{
			if(@event!=null)
				@event(source, eventArgs);
		}
	}
}
