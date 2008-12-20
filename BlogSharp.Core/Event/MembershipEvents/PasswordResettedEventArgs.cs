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
		public PasswordResettedEventArgs(IAuthor author,string newPassword)
		{
			this.Author = author;
			this.NewPassword = newPassword;
		}

		public IAuthor Author { get; private set; }
        public string NewPassword { get; private set; }
	}
}
