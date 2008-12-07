using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class PasswordResettedEvent:AbstractEvent<IMembershipService>
	{
		public PasswordResettedEvent(IAuthor author,string newPassword,IMembershipService service)
			: base(service)
		{
			this.Author = author;
			this.NewPassword = newPassword;
		}

		public IAuthor Author { get; set; }
		public string NewPassword { get; set; }
	}
}
