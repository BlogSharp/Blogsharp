using System;
using System.Collections.Generic;
using System.Linq;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Model;
using Db4objects.Db4o;

namespace BlogSharp.Db4o.Repositories
{
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
		/// <param name="blogId"></param>
		/// <returns></returns>
		public IList<IPost> GetByBlog(int blogId)
		{
			return container.GetContainer().Query<IPost>(x => x.Blog.Id == blogId,
			                                             (x, y) => y.DatePublished.CompareTo(x.DatePublished));
		}

		/// <summary>
		/// Get the Post List of the Blog, with paging support.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<IPost> GetByBlog(int blogId, int skip, int take)
		{
			return container.GetContainer().Query<IPost>(x => x.Blog.Id == blogId,
			                                             (x, y) => x.DatePublished.CompareTo(y.DatePublished))
				.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Get the Post list via selected date on the calander.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="date"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<IPost> GetByDate(int blogId, DateTime date, int skip, int take)
		{
			date = date.Date;
			return container.GetContainer().Query<IPost>(x => x.Blog.Id == blogId && x.DatePublished >= date)
				.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Get the Post list of the User.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="authorId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<IPost> GetByAuthor(int blogId, int authorId, int skip, int take)
		{
			return container.GetContainer().Query<IPost>(x => x.Blog.Id == blogId && x.User.Id == authorId)
				.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Get the Post list via Tag.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="tagId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public IList<IPost> GetByTag(int blogId, int tagId, int skip, int take)
		{
			var tag = container.GetContainer().Query<ITag>(x => x.Id == tagId).SingleOrDefault();
			return tag.Posts.Skip(skip).Take(take).ToList();
		}

		/// <summary>
		/// Saves the post
		/// </summary>
		/// <param name="post"></param>
		public void SavePost(IPost post)
		{
			SaveObject(post);
		}

		/// <summary>
		/// Delete post
		/// </summary>
		/// <param name="post"></param>
		public void DeletePost(IPost post)
		{
			RemoveObject(post);
		}

		/// <summary>
		/// Adds the comment
		/// </summary>
		/// <param name="comment"></param>
		public void SaveComment(IPostComment comment)
		{
			SaveObject(comment);
		}

		/// <summary>
		/// Delete comment
		/// </summary>
		/// <param name="comment"></param>
		public void DeleteComment(IPostComment comment)
		{
			comment.Post.Comments.Remove(comment);
			RemoveObject(comment);
			SaveObject(comment.Post);
		}

		/// <summary>
		/// Get the post via SEO friendly title in url-rewrite.
		/// </summary>
		/// <param name="friendlyTitle"></param>
		/// <returns></returns>
		public IPost GetByTitle(string friendlyTitle)
		{
			return container.GetContainer().Query<IPost>(x => x.FriendlyTitle == friendlyTitle).SingleOrDefault();
		}

		public IPost GetPostById(int id)
		{
			return container.GetContainer().Query<IPost>(x => x.Id == id).SingleOrDefault();
		}

		#endregion
	}
}
