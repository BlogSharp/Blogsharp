using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddingEvent:AbstractEvent<IPostService>,ICancellableEvent<IPostService>
	{
		public PostAddingEvent(IPostService postService,IPost post):base(postService)
		{
			this.Cancel = false;
			this.Post = post;
		}
		#region ICancellableEvent<IPostService> Members

		public bool Cancel
		{ 
			get;
			set;
		}

		#endregion

		public IPost Post { get; set; }
	}
}
