namespace BlogSharp.Core.Event.PostEvents
{
	using Model;
	using Services.Post;

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