using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddedEventArgs : AbstractEventArgs<IPostService>
	{
		public CommentAddedEventArgs(IPostService postService, PostComment comment)
			: base(postService)
		{
			Comment = comment;
		}

		public PostComment Comment { get; private set; }
	}
}