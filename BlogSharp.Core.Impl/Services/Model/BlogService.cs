using System;
using System.Collections.Generic;
using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Services.Model;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Services.Model
{
	public class BlogService : IBlogService
	{
		private readonly IBlogRepository blogRepository;
		public BlogService(IBlogRepository blogRepository)
		{
			this.blogRepository = blogRepository;
		}

		#region Implementation of IBlogService

		public void SaveBlog(IBlog blog)
		{
			if (Guid.Empty.Equals(blog.Id))
				blog.Id = Guid.NewGuid();

			blogRepository.SaveBlog(blog);
		}

		public void DeleteBlog(IBlog blog)
		{
			blogRepository.DeleteBlog(blog);
		}

		public IBlog GetById(Guid id)
		{
			return blogRepository.GetAllBlogs().Where(x => x.Id == id).SingleOrDefault();
		}

		public IBlog GetByFounder(Guid userId)
		{
			return blogRepository.GeyByFounder(userId);
		}

		public IList<IBlog> GetAllBlogs()
		{
			return blogRepository.GetAllBlogs();
		}

		#endregion
	}
}
