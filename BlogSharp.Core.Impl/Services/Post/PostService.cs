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
			this.PostAdding.Raise(postAdding);
			if (postAdding.Cancel)
				return;
			this.postRepository.SavePost(post);
			var postAdded = new PostAddedEventArgs(this, post);
			this.PostAdded.Raise(postAdded);
		}

		public void AddComment(PostComment comment)
		{
			var commentAdding = new CommentAddingEventArgs(this, comment);
			this.CommentAdding.Raise(commentAdding);
			if (commentAdding.Cancel)
				return;
			this.postRepository.SaveComment(comment);
			var commentAdded = new CommentAddedEventArgs(this, comment);
			this.CommentAdded.Raise(commentAdded);
		}

		public void RemoveComment(PostComment comment)
		{
			this.postRepository.DeleteComment(comment);
		}

		public void RemovePost(Model.Post post)
		{
			var postRemoving = new PostRemovingEventArgs(this, post);
			this.PostRemoving.Raise(postRemoving);
			if (postRemoving.Cancel)
				return;
			this.postRepository.DeletePost(post);
			var postRemoved = new PostRemovedEventArgs(this, post);
			this.PostRemoved.Raise(postRemoved);
		}

		public Model.Post GetPostById(Blog blog, int id)
		{
			return this.postRepository.GetPostById(blog, id);
		}

		public Model.Post GetPostByFriendlyTitle(Blog blog, string friendlyTitle)
		{
			return this.postRepository.GetByTitle(blog, friendlyTitle);
		}

		public IList<Model.Post> GetPostsByBlog(Blog blog)
		{
			return this.postRepository.GetByBlog(blog);
		}

		public IList<Model.Post> GetPostsByBlogPaged(Blog blog, int skip, int take)
		{
			return this.postRepository.GetByBlog(blog, skip, take);
		}

		public IList<Model.Post> GetPostsByTagPaged(Blog blog, string friendlyTagName, int skip, int take)
		{
			return this.postRepository.GetByTag(blog, friendlyTagName, skip, take);
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