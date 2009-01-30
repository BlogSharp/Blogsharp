﻿using BlogSharp.Core.Services.Membership;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatingEvent : AbstractEventArgs<IMembershipService>, ICancellableEvent
	{
		public UserValidatingEvent(IMembershipService service, string userName, string password)
			: base(service)
		{
			Username = userName;
			Password = password;
		}

		public string Password { get; set; }
		public string Username { get; set; }

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}