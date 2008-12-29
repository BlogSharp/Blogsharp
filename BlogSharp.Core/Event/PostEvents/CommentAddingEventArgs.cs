using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddingEventArgs : AbstractEventArgs, ICancellableEvent
	{

		public CommentAddingEventArgs(IPostComment comment)
		{
			this.Comment = comment;
		}

        public IPostComment Comment
        {
            get; private set;
        }

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}