using System;
using System.Web;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Web.Modules;

namespace BlogSharp.Core.Impl.Web.Modules
{
	public class BlogContextModule : IBlogSharpHttpModule
	{
		private readonly IBlogRepository blogRepository;

		public BlogContextModule(IBlogRepository blogRepository)
		{
			this.blogRepository = blogRepository;
		}

		#region IBlogSharpHttpModule Members

		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += HandleBeginRequest;
		}

		#endregion

		protected virtual void HandleBeginRequest(object sender, EventArgs e)
		{
			string host = HttpContext.Current.Request.Headers["HOST"];
			BlogContext context = new BlogContext();
			context.Blog = blogRepository.GetBlog();
			BlogContext.Current = context;
		}
	}
}