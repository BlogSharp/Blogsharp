using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostRemovedEvent:AbstractEvent<IPostService>
	{
		public PostRemovedEvent(IPostService postService, IPost post):base(postService)
		{
			this.Post = post;
		}

		public IPost Post { get; set; }
	}
}
