using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddingEventArgs : AbstractEventArgs, ICancellableEvent
	{
		private readonly IPost post;

		public PostAddingEventArgs(IPost post)
		{
			this.post = post;
		}

		public IPost Post
		{
			get { return post; }
		}

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}