using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostRemovingEvent:AbstractEvent<IPostService>,ICancellableEvent
	{
		public PostRemovingEvent(IPostService postService,IPost post):base(postService)
		{
			
		}

		public IPost Post { get; set; }

		#region ICancellableEvent Members

		public bool Cancel
		{
			get; set;
		}

		#endregion
	}
}
