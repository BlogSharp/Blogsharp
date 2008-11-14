using BlogSharp.Core.Services.Post;

namespace BlogSharp.Core.Event.MembershipEvents
{
	public class UserValidatedEvent : AbstractEvent<IPostService>
	{
		public UserValidatedEvent(IPostService postService) : base(postService)
		{
		}
	}
}