using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddedEventArgs : AbstractEventArgs<IPostService>
	{
		public PostAddedEventArgs(IPostService postService, Post post)
			: base(postService)
		{
			Post = post;
		}

		public Post Post { get; protected set; }
	}
}