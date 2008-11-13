using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddedEvent:AbstractEvent<string>
	{
		public CommentAddedEvent():base(null)
		{
			
		}
	}
}
