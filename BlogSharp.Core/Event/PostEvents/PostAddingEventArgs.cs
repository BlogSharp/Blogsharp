using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddingEventArgs : AbstractEventArgs<IPostService>, ICancellableEvent
	{
		private readonly IPost post;

		public PostAddingEventArgs(IPostService postService,IPost post)
			:base(postService)
		{
			this.post = post;
		}

		public IPost Post
		{
			get { return post; }
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}