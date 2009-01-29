using System;
using System.Collections.Generic;
using BlogSharp.Model;

namespace BlogSharp.Core.Persistence.Repositories
{
	public interface IPostRepository
	{
		/// <summary>
		/// Get the Post list of the Blog
		/// </summary>
		/// <param name="blogId"></param>
		/// <returns></returns>
		IList<Model.Post> GetByBlog(int blogId);
		/// <summary>
		/// Get the Post List of the Blog, with paging support.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByBlog(int blogId, int skip, int take);
		/// <summary>
		/// Get the Post list via selected date on the calander.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="date"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByDate(int blogId, DateTime date, int skip, int take);
		/// <summary>
		/// Get the Post list of the User.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="authorId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByAuthor(int blogId, int authorId, int skip, int take);
		/// <summary>
		/// Get the Post list via Tag.
		/// </summary>
		/// <param name="blogId"></param>
		/// <param name="tagId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByTag(int blogId, int tagId, int skip, int take);

		/// <summary>
		/// Saves the post
		/// </summary>
		/// <param name="post"></param>
		void SavePost(Post post);

		/// <summary>
		/// Delete post
		/// </summary>
		/// <param name="post"></param>
		void DeletePost(Post post);

		/// <summary>
		/// Adds the comment
		/// </summary>
		/// <param name="comment"></param>
		void SaveComment(PostComment comment);

		/// <summary>
		/// Delete comment
		/// </summary>
		/// <param name="comment"></param>
		void DeleteComment(PostComment comment);

		/// <summary>
		/// Get the post via SEO friendly title in url-rewrite.
		/// </summary>
		/// <param name="friendlyTitle"></param>
		/// <returns></returns>
		Post GetByTitle(string friendlyTitle);

		Post GetPostById(int id);
	}
}