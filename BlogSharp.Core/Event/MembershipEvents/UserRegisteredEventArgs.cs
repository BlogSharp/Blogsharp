using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserRegisteredEventArgs : AbstractEventArgs<IMembershipService>
	{
		public UserRegisteredEventArgs(IMembershipService service, User user)
			: base(service)
		{
			User = user;
		}

		public User User { get; private set; }
	}
}