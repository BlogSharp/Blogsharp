using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddedEvent : AbstractEvent<IPostService>
	{
		public CommentAddedEvent(IPostService postService,IPostComment comment) : base(postService)
		{
			this.Comment = comment;
		}

		public IPostComment Comment { get; set; }
	}
}
