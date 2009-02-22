namespace BlogSharp.Core.Event.PostEvents
{
	using Model;
	using Services.Post;

	public class CommentAddedEventArgs : AbstractEventArgs<IPostService>
	{
		public CommentAddedEventArgs(IPostService postService, PostComment comment)
			: base(postService)
		{
			this.Comment = comment;
		}

		public PostComment Comment { get; private set; }
	}
}