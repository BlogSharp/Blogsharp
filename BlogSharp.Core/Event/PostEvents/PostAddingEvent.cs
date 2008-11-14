using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddingEvent : AbstractEvent<IPostService>, ICancellableEvent
	{
		private readonly IPost post;

		public PostAddingEvent(IPostService postService, IPost post) : base(postService)
		{
			Cancel = false;
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