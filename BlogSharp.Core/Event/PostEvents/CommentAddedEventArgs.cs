namespace BlogSharp.Core.Event.PostEvents
{
	using Model;
	using Services.Post;

	public class CommentAddedEventArgs : AbstractEventArgs<IPostService>
	{
		public CommentAddedEventArgs(IPostService postService, Feedback comment)
			: base(postService)
		{
			Comment = comment;
		}

		public Feedback Comment { get; private set; }
	}
}