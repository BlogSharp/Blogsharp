using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Services.Post
{
	public class PostService : IPostService
	{
		public PostService(IPostRepository postRepository)
		{
			this.postRepository = postRepository;
		}
		private readonly IPostRepository postRepository;
		#region IPostService Members

		public void AddPost(IPost post)
		{
			var postAdding = new PostAddingEventArgs(post);
			this.PostAdding.Raise(this,postAdding);
			if (postAdding.Cancel)
				return;
			this.postRepository.SavePost(post);
			var postAdded = new PostAddedEventArgs(post);
			this.PostAdded.Raise(this,postAdded);
		}

		public void AddComment(IPostComment comment)
		{
			var commentAdding = new CommentAddingEventArgs(comment);
			this.CommentAdding.Raise(this,commentAdding);
			if (commentAdding.Cancel)
				return;
			this.postRepository.SaveComment(comment);
			var commentAdded = new CommentAddedEventArgs(comment);
			this.CommentAdded.Raise(this,commentAdded);
		}

		public void RemoveComment(IPostComment comment)
		{
			postRepository.DeleteComment(comment);
		}

		public void RemovePost(IPost post)
		{
			var postRemoving = new PostRemovingEventArgs(post);
			this.PostRemoving.Raise(this,postRemoving);
			if (postRemoving.Cancel)
				return;
			postRepository.DeletePost(post);
			var postRemoved = new PostRemovedEventArgs(post);
			this.PostRemoved.Raise(this,postRemoved);
		}

		public IPost GetPostById(int id)
		{
			return postRepository.GetPostById(id);
		}

		public IPost GetPostByFriendlyTitle(string friendlyTitle)
		{
			return postRepository.GetByTitle(friendlyTitle);
		}

		#endregion

		#region IPostService Members


		public event EventHandler<IPostService, PostAddingEventArgs> PostAdding = delegate { };
		public event EventHandler<IPostService, PostAddedEventArgs> PostAdded = delegate { };
		public event EventHandler<IPostService, PostRemovingEventArgs> PostRemoving = delegate { };
		public event EventHandler<IPostService, PostRemovedEventArgs> PostRemoved = delegate { };
		public event EventHandler<IPostService, CommentAddingEventArgs> CommentAdding = delegate { };
		public event EventHandler<IPostService, CommentAddedEventArgs> CommentAdded = delegate { };
		#endregion
	}
}