namespace BlogSharp.Core.Persistence.Repositories
{
	using System;
	using System.Collections.Generic;
	using Model;

	public interface IPostRepository
	{
		/// <summary>
		/// Get the Post list of the Blog
		/// </summary>
		/// <param name="blog"></param>
		/// <returns></returns>
		IList<Model.Post> GetByBlog(Blog blog);

		/// <summary>
		/// Get the Post List of the Blog, with paging support.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByBlog(Blog blog, int skip, int take);

		/// <summary>
		/// Get the Post list via selected date on the calander.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="date"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByDate(Blog blog, DateTime date, int skip, int take);

		/// <summary>
		/// Get the Post list of the User.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="authorId"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByAuthor(Blog blog, int authorId, int skip, int take);

		/// <summary>
		/// Get the Post list via Tag.
		/// </summary>
		/// <param name="blog"></param>
		/// <param name="friendlyTagName"></param>
		/// <param name="skip"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		IList<Model.Post> GetByTag(Blog blog, string friendlyTagName, int skip, int take);

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
		/// <param name="blog"></param>
		/// <param name="friendlyTitle"></param>
		/// <returns></returns>
		Post GetByTitle(Blog blog, string friendlyTitle);

		/// <param name="blog"></param>
		/// <param name="id"></param>
		Post GetPostById(Blog blog, int id);
	}
}