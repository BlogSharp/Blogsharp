using System.Collections.Generic;
using BlogSharp.Model;

namespace BlogSharp.Core.Persistence.Repositories
{
	public interface IBlogRepository
	{
		Blog GetBlog();


		/// <summary>
		/// Saves the blog
		/// </summary>
		/// <param name="blog"></param>
		void SaveBlog(Blog blog);

		/// <summary>
		/// Removes the blog
		/// </summary>
		/// <param name="blog"></param>
		void DeleteBlog(Blog blog);
	}
}