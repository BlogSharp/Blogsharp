using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatingEvent:AbstractEvent<IPostService>,ICancellableEvent
	{
		public UserValidatingEvent(IPostService postService):base(postService)
		{
			
		}

		public string Username { get; set; }


		#region ICancellableEvent Members

		public bool Cancel
		{ 
			get;
			set;
		}

		#endregion
	}
}
