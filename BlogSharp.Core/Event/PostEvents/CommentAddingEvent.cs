using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddingEvent : AbstractEvent<IPostService>, ICancellableEvent
	{
		private readonly IPostComment postComment;

		public CommentAddingEvent(IPostService service, IPostComment comment) : base(service)
		{
			postComment = comment;
		}

		public IPostComment PostComment
		{
			get { return postComment; }
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}