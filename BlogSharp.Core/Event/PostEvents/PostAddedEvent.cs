using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddedEvent : AbstractEvent<IPostService>
	{
		public PostAddedEvent(IPostService postService,IPost post) : base(postService)
		{
			this.Post = post;
		}

		public IPost Post { get; protected set; }
	}
}
