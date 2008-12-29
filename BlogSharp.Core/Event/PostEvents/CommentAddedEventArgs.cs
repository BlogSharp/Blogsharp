using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddedEventArgs : AbstractEventArgs
	{
		public CommentAddedEventArgs(IPostComment comment)
		{
			this.Comment = comment;
		}

		public IPostComment Comment { get; private set; }
	}
}
