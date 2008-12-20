using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostRemovingEventArgs:AbstractEventArgs,ICancellableEvent
	{
		public PostRemovingEventArgs(IPost post)
		{
		    this.Post = post;	
		}

		public IPost Post { get; private set; }

		#region ICancellableEvent Members

		public bool Cancel
		{
			get; set;
		}

		#endregion
	}
}
