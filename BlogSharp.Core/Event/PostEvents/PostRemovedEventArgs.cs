using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostRemovedEventArgs : AbstractEventArgs<IPostService>
	{
		public PostRemovedEventArgs(IPostService postService, Post post)
			: base(postService)
		{
			Post = post;
		}

		public Post Post { get; private set; }
	}
}