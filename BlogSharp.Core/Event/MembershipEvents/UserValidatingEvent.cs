namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatingEvent : AbstractEventArgs, ICancellableEvent
	{
		public UserValidatingEvent(string userName,string password)
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