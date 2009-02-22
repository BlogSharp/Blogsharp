namespace BlogSharp.Core.Event.MembershipEvents
{
	using Services.Membership;

	public class UserValidatingEvent : AbstractEventArgs<IMembershipService>, ICancellableEvent
	{
		public UserValidatingEvent(IMembershipService service, string userName, string password)
			: base(service)
		{
			this.Username = userName;
			this.Password = password;
		}

		public string Password { get; set; }
		public string Username { get; set; }

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}