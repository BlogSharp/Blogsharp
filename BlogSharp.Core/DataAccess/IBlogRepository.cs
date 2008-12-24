using System.Collections.Generic;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IBlogRepository
    {
        /// <summary>
        /// Get the Blog of the Founder User
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        IBlog GeyByFounder(int authorId);

		/// <summary>
		/// Gets all blog
		/// </summary>
		/// <returns></returns>
    	IList<IBlog> GetAllBlogs();

		/// <summary>
		/// Saves the blog
		/// </summary>
		/// <param name="blog"></param>
    	void SaveBlog(IBlog blog);

		/// <summary>
		/// Removes the blog
		/// </summary>
		/// <param name="blog"></param>
    	void DeleteBlog(IBlog blog);
    }
}
