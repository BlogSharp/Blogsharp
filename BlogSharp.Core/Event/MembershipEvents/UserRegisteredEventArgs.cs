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
		public UserRegisteredEventArgs(IMembershipService service,IUser user)
			:base(service)
		{
			this.User = user;
		}

		public IUser User { get; private set; }
	}
}
