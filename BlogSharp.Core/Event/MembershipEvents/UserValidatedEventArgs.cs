using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatedEventArgs : AbstractEventArgs<IMembershipService>
	{
		public UserValidatedEventArgs(IMembershipService membershipService, User user)
			: base(membershipService)
		{
			User = user;
		}

		public User User { get; set; }
	}
}