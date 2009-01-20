using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class PasswordResettedEventArgs:AbstractEventArgs<IMembershipService>
	{
		public PasswordResettedEventArgs(IMembershipService service,IUser user, string newPassword)
			:base(service)
		{
			this.User = user;
			this.NewPassword = newPassword;
		}

		public IUser User { get; private set; }
        public string NewPassword { get; private set; }
	}
}
