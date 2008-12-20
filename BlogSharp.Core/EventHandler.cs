using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core
{
    public delegate void EventHandler<TSource,TEventArgs>(TSource source,TEventArgs eventArgs);
	public static class EventHandlerHelpers
	{
		public static void Raise<TSource,TEventArgs>(this EventHandler<TSource,TEventArgs> @event,TSource source,TEventArgs eventArgs)
		{
			if(@event!=null)
				@event(source, eventArgs);
		}
	}
}
