namespace BlogSharp.Core.Event.PostEvents
{
	using Model;
	using Services.Post;

	public class PostAddingEventArgs : AbstractEventArgs<IPostService>, ICancellableEvent
	{
		private readonly Post post;

		public PostAddingEventArgs(IPostService postService, Post post)
			: base(postService)
		{
			this.post = post;
		}

		public Post Post
		{
			get { return post; }
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}