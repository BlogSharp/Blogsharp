namespace BlogSharp.Core.Event.PostEvents
{
	using Model;
	using Services.Post;

	public class PostRemovedEventArgs : AbstractEventArgs<IPostService>
	{
		public PostRemovedEventArgs(IPostService postService, Post post)
			: base(postService)
		{
			this.Post = post;
		}

		public Post Post { get; private set; }
	}
}