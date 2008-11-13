using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddedEvent:AbstractEvent<IPostService>
	{
		public PostAddedEvent(IPostService postService):base(postService)
		{
			
		}
		public IPost Post { get; protected set; }
	}
}
