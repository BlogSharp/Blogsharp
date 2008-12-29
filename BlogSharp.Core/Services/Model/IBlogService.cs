using System;
using System.Collections.Generic;
using BlogSharp.Model;

namespace BlogSharp.Core.Services.Model
{
	public interface IBlogService
	{
		void SaveBlog(IBlog blog);
		void DeleteBlog(IBlog blog);

		IBlog GetById(Guid id);
		IBlog GetByFounder(Guid userId);

		IList<IBlog> GetAllBlogs();
	}
}
