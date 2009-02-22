namespace BlogSharp.Db4o.Blog.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core.Persistence.Repositories;
	using Model;

	public class PostRepository : Db4oRepository, IPostRepository
	{
		public PostRepository(IObjectContainerManager container)
			: base(container)
		{
		}

		#region Implementation of IPostRepository

		/// <summary>
		/// Get the Post list of the Blog
		/// </summary>
		/// <param name="blog"></param>
		/// <returns></returns>
		public IList<Post> GetByBlog(BlogSharp.Model.Blog blog)
		{
			return this.container.GetContainer().Query<Post>(x => x.Blog == blog,
			                                                 (x, y) => y.DatePublished.CompareTo(x.DatePublished));
		}

		/// <summary>
		/// Get the Post List of the Blog, with paging support.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<Post> GetByBlog(BlogSharp.Model.Blog blog, int skip, int take)
		{
			return this.container.GetContainer().Query<Post>(x => x.Blog == blog,
			                                                 (x, y) => x.DatePublished.CompareTo(y.DatePublished))
				.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Get the Post list via selected date on the calander.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="date"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<Post> GetByDate(BlogSharp.Model.Blog blog, DateTime date, int skip, int take)
		{
			date = date.Date;
			return this.container.GetContainer().Query<Post>(x => x.Blog == blog && x.DatePublished >= date)
				.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Get the Post list of the User.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="authorId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<Post> GetByAuthor(BlogSharp.Model.Blog blog, int authorId, int skip, int take)
		{
			return this.container.GetContainer()
				.Query<Post>(x => x.Blog == blog &&
				                  x.User.ID == authorId)
				.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Get the Post list via Tag.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="friendlyTagName"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<Post> GetByTag(BlogSharp.Model.Blog blog, string friendlyTagName, int skip, int take)
		{
			var tag =
				this.container.GetContainer().Query<Tag>(x => x.FriendlyName == friendlyTagName && x.Blog == blog).SingleOrDefault();
			if (tag == null)
				return null;
			this.container.GetContainer().Activate(tag, 3);
			return tag.Posts.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Saves the post
		/// </summary>
		/// <param name="post"></param>
		public void SavePost(Post post)
		{
			this.SaveObject(post);
			this.SaveObject(post.Comments);
			this.SaveObject(post.Tags);
		}

		/// <summary>
		/// Delete post
		/// </summary>
		/// <param name="post"></param>
		public void DeletePost(Post post)
		{
			this.RemoveObject(post);
		}

		/// <summary>
		/// Adds the comment
		/// </summary>
		/// <param name="comment"></param>
		public void SaveComment(PostComment comment)
		{
			if (!comment.Post.Comments.Contains(comment))
				comment.Post.AddComment(comment);
			this.SaveObject(comment.Post.Comments);
			this.SaveObject(comment);
		}

		/// <summary>
		/// Delete comment
		/// </summary>
		/// <param name="comment"></param>
		public void DeleteComment(PostComment comment)
		{
			comment.Post.Comments.Remove(comment);
			this.SaveObject(comment.Post.Comments);
			this.RemoveObject(comment);
		}

		/// <summary>
		/// Get the post via SEO friendly title in url-rewrite.
		/// </summary>
		/// <param name="friendlyTitle"></param>
		/// <returns></returns>
		public Post GetByTitle(BlogSharp.Model.Blog blog, string friendlyTitle)
		{
			return this.container.GetContainer()
				.Query<Post>(x => x.FriendlyTitle == friendlyTitle)
				.SingleOrDefault();
		}

		public Post GetPostById(BlogSharp.Model.Blog blog, int id)
		{
			return this.container.GetContainer()
				.Query<Post>(x => x.ID == id)
				.SingleOrDefault();
		}

		#endregion
	}
}