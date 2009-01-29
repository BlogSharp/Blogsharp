using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using BlogSharp.Core.Persistence.Repositories;

namespace BlogSharp.Core.Web.Modules
{
	public class BlogContextModule : IBlogSharpHttpModule
	{
		private readonly HttpApplication application;
		private readonly HttpApplicationEventWrapper eventWrapper;
		private readonly IBlogRepository blogRepository;
		public BlogContextModule(
			HttpApplication application,
			HttpApplicationEventWrapper eventWrapper,
			IBlogRepository blogRepository)
		{
			this.application = application;
			this.eventWrapper = eventWrapper;
			this.blogRepository = blogRepository;
		}

		protected virtual void HandleBeginRequest(object sender, EventArgs e)
		{
			string host = HttpContext.Current.Request.Headers["HOST"];
			BlogContext context = new BlogContext();
			context.Blog = blogRepository.GetBlog();
			BlogContext.Current = context;
		}


		#region IBlogSharpHttpModule Members

		public void Start()
		{
			this.eventWrapper.BeginRequest += HandleBeginRequest;
		}

		public void Stop()
		{
			this.eventWrapper.BeginRequest -= HandleBeginRequest;
		}

		#endregion
	}
}