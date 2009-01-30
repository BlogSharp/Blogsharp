using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostRemovingEventArgs : AbstractEventArgs<IPostService>, ICancellableEvent
	{
		public PostRemovingEventArgs(IPostService postService, Post post)
			: base(postService)
		{
			Post = post;
		}

		public Post Post { get; private set; }

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}