using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserRegisteredEventArgs : AbstractEventArgs<IMembershipService>
	{
		public UserRegisteredEventArgs(IMembershipService service,User user)
			:base(service)
		{
			this.User = user;
		}

		public User User { get; private set; }
	}
}
