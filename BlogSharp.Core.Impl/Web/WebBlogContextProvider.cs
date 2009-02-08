using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BlogSharp.Core.Persistence.Repositories;

namespace BlogSharp.Core.Impl.Web
{
	public class WebBlogContextProvider:BlogContextProvider
	{
		public WebBlogContextProvider(IBlogRepository blogRepository)
		{
			this.blogRepository = blogRepository;
		}

		private readonly IBlogRepository blogRepository;
		private const string BLOGCONTEXTKEY = "blogcontext";
		#region IBlogContextProvider Members

		public override BlogContext GetCurrentBlogContext()
		{
			var items = HttpContext.Current.Items;
			if (items[BLOGCONTEXTKEY] == null)
			{
				var blogContext = new BlogContext();
				blogContext.Blog = blogRepository.GetBlog();
				items[BLOGCONTEXTKEY] = blogContext;
			}
				

			return items[BLOGCONTEXTKEY] as BlogContext;
		}

		#endregion
	}
}
