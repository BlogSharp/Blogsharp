using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class PostAddedEventArgs : AbstractEventArgs
	{
		public PostAddedEventArgs(IPost post)
		{
			this.Post = post;
		}

		public IPost Post { get; protected set; }
	}
}
