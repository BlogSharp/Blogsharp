using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event
{
	public abstract class AbstractEvent<TSource>:IEvent<TSource>
	{

		/// <param name="source">The source that the event is raised from</param>
		protected AbstractEvent(TSource source)
		{
			this.EventSource = source;
		}
		#region IEvent<TSource> Members

		public TSource EventSource
		{
			get; set;
		}

		#endregion
	}
}
