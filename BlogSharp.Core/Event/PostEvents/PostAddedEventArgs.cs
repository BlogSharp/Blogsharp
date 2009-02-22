namespace BlogSharp.Core.Event.PostEvents
{
	using Model;
	using Services.Post;

	public class PostAddedEventArgs : AbstractEventArgs<IPostService>
	{
		public PostAddedEventArgs(IPostService postService, Post post)
			: base(postService)
		{
			this.Post = post;
		}

		public Post Post { get; protected set; }
	}
}