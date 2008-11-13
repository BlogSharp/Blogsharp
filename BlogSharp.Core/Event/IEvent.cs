using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event
{
	public interface IEvent<TSource>
	{
		/// <summary>
		/// The source that the event is raised from
		/// </summary>
		TSource EventSource { get; set; }
	}
}
