namespace BlogSharp.Core.Impl.Services.Post
{
	using System.Collections.Generic;
	using Core.Services.Post;
	using Event.PostEvents;
	using Model;
	using Persistence.Repositories;

	public class PostService : IPostService
	{
		private readonly IPostRepository postRepository;

		public PostService(IPostRepository postRepository)
		{
			this.postRepository = postRepository;
		}

		#region IPostService Members

		public void AddPost(Model.Post post)
		{
			var postAdding = new PostAddingEventArgs(this, post);
			PostAdding.Raise(postAdding);
			if (postAdding.Cancel)
				return;
			postRepository.SavePost(post);
			var postAdded = new PostAddedEventArgs(this, post);
			PostAdded.Raise(postAdded);
		}

		public void AddComment(PostComment comment)
		{
			var commentAdding = new CommentAddingEventArgs(this, comment);
			CommentAdding.Raise(commentAdding);
			if (commentAdding.Cancel)
				return;
			postRepository.SaveComment(comment);
			var commentAdded = new CommentAddedEventArgs(this, comment);
			CommentAdded.Raise(commentAdded);
		}

		public void RemoveComment(PostComment comment)
		{
			postRepository.DeleteComment(comment);
		}

		public void RemovePost(Model.Post post)
		{
			var postRemoving = new PostRemovingEventArgs(this, post);
			PostRemoving.Raise(postRemoving);
			if (postRemoving.Cancel)
				return;
			postRepository.DeletePost(post);
			var postRemoved = new PostRemovedEventArgs(this, post);
			PostRemoved.Raise(postRemoved);
		}

		public Model.Post GetPostById(Blog blog, int id)
		{
			return postRepository.GetPostById(blog, id);
		}

		public Model.Post GetPostByFriendlyTitle(Blog blog, string friendlyTitle)
		{
			return postRepository.GetByTitle(blog, friendlyTitle);
		}

		public IList<Model.Post> GetPostsByBlog(Blog blog)
		{
			return postRepository.GetByBlog(blog);
		}

		public IList<Model.Post> GetPostsByBlogPaged(Blog blog, int skip, int take)
		{
			return postRepository.GetByBlog(blog, skip, take);
		}

		public IList<Model.Post> GetPostsByTagPaged(Blog blog, string friendlyTagName, int skip, int take)
		{
			return postRepository.GetByTag(blog, friendlyTagName, skip, take);
		}


		public event EventHandler<PostAddingEventArgs> PostAdding = delegate { };
		public event EventHandler<PostAddedEventArgs> PostAdded = delegate { };
		public event EventHandler<PostRemovingEventArgs> PostRemoving = delegate { };
		public event EventHandler<PostRemovedEventArgs> PostRemoved = delegate { };
		public event EventHandler<CommentAddingEventArgs> CommentAdding = delegate { };
		public event EventHandler<CommentAddedEventArgs> CommentAdded = delegate { };

		#endregion
	}
}