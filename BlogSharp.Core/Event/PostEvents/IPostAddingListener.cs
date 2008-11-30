using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event.PostEvents
{
	public interface IPostAddingListener:IEventListener<PostAddingEvent>
	{
		
	}
}
