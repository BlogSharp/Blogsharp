using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatedEventArgs : AbstractEventArgs
	{
		public UserValidatedEventArgs(IUser user)
		{
            this.User = user;
		}

	    public IUser User { get; set; }
	}
}