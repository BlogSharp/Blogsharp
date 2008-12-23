using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class PasswordResettedEventArgs:AbstractEventArgs
	{
		public PasswordResettedEventArgs(IUser user,string newPassword)
		{
			this.User = user;
			this.NewPassword = newPassword;
		}

		public IUser User { get; private set; }
        public string NewPassword { get; private set; }
	}
}
