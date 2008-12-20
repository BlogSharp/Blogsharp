using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatedEventArgs : AbstractEventArgs
	{
		public UserValidatedEventArgs(IAuthor user)
		{
            this.User = user;
		}

	    public IAuthor User { get; set; }
	}
}