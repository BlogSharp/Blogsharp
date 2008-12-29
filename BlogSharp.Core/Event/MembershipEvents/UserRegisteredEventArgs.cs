using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserRegisteredEventArgs : AbstractEventArgs
	{
		public UserRegisteredEventArgs(IUser user)
		{
			this.User = user;
		}

		public IUser User { get; private set; }
	}
}
