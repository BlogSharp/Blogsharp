using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserRegisteredEventArgs : AbstractEventArgs
	{
		public UserRegisteredEventArgs(IAuthor author)
		{
			this.User = author;
		}

		public IAuthor User { get; private set; }
	}
}
