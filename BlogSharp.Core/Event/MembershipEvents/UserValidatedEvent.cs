using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatedEvent:AbstractEvent<IPostService>
	{
		public UserValidatedEvent(IPostService postService):base(postService)
		{
			
		}
	}
}
