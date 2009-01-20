using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddedEventArgs : AbstractEventArgs<IPostService>
	{
		public CommentAddedEventArgs(IPostService postService,IPostComment comment)
			:base(postService)
		{
			this.Comment = comment;
		}

		public IPostComment Comment { get; private set; }
	}
}
