using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;
using Castle.Services.Transaction;

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

		public void AddPost(Model.Post post)
		{
			var postAdding = new PostAddingEventArgs(this,post);
			this.PostAdding.Raise(postAdding);
			if (postAdding.Cancel)
				return;
			this.postRepository.SavePost(post);
			var postAdded = new PostAddedEventArgs(this,post);
			this.PostAdded.Raise(postAdded);
		}

		public void AddComment(PostComment comment)
		{
			var commentAdding = new CommentAddingEventArgs(this,comment);
			this.CommentAdding.Raise(commentAdding);
			if (commentAdding.Cancel)
				return;
			this.postRepository.SaveComment(comment);
			var commentAdded = new CommentAddedEventArgs(this,comment);
			this.CommentAdded.Raise(commentAdded);
		}

		public void RemoveComment(PostComment comment)
		{
			postRepository.DeleteComment(comment);
		}

		public void RemovePost(Model.Post post)
		{
			var postRemoving = new PostRemovingEventArgs(this,post);
			this.PostRemoving.Raise(postRemoving);
			if (postRemoving.Cancel)
				return;
			postRepository.DeletePost(post);
			var postRemoved = new PostRemovedEventArgs(this,post);
			this.PostRemoved.Raise(postRemoved);
		}

		public Model.Post GetPostById(int id)
		{
			return postRepository.GetPostById(id);
		}

		public Model.Post GetPostByFriendlyTitle(string friendlyTitle)
		{
			return postRepository.GetByTitle(friendlyTitle);
		}

		public IList<Model.Post> GetPostsByBlog(Blog blog)
		{
			return postRepository.GetByBlog(blog.Id, 0, 10);
		}
		#endregion

		#region IPostService Members


		public event EventHandler<PostAddingEventArgs> PostAdding = delegate { };
		public event EventHandler<PostAddedEventArgs> PostAdded = delegate { };
		public event EventHandler<PostRemovingEventArgs> PostRemoving = delegate { };
		public event EventHandler<PostRemovedEventArgs> PostRemoved = delegate { };
		public event EventHandler<CommentAddingEventArgs> CommentAdding = delegate { };
		public event EventHandler<CommentAddedEventArgs> CommentAdded = delegate { };
		#endregion


		#region IPostService Members


		public IList<Model.Post> GetPostsByBlogPaged(Blog blog, int skip, int take)
		{
			return postRepository.GetByBlog(blog.Id, skip, take);
		}

		#endregion
	}
}