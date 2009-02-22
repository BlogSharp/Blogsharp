namespace BlogSharp.Core.Event.MembershipEvents
{
	using Model;
	using Services.Membership;

	public class UserRegisteredEventArgs : AbstractEventArgs<IMembershipService>
	{
		public UserRegisteredEventArgs(IMembershipService service, User user)
			: base(service)
		{
			this.User = user;
		}

		public User User { get; private set; }
	}
}