using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class PasswordResettedEventArgs : AbstractEventArgs<IMembershipService>
	{
		public PasswordResettedEventArgs(IMembershipService service, User user, string newPassword)
			: base(service)
		{
			User = user;
			NewPassword = newPassword;
		}

		public User User { get; private set; }
		public string NewPassword { get; private set; }
	}
}