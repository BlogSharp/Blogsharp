using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatedEventArgs : AbstractEventArgs<IMembershipService>
	{
		public UserValidatedEventArgs(IMembershipService membershipService,IUser user)
			: base(membershipService)
		{
            this.User = user;
		}

	    public IUser User { get; set; }
	}
}