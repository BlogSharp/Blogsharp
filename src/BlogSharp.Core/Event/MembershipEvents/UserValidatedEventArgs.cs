namespace BlogSharp.Core.Event.MembershipEvents
{
	using Model;
	using Services.Membership;

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