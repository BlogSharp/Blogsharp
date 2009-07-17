namespace BlogSharp.Core.Impl.Web
{
	using System.Web;
	using Persistence.Repositories;

	public class WebBlogContextProvider : BlogContextProvider
	{
		private const string BLOGCONTEXTKEY = "blogcontext";
		private readonly IBlogRepository blogRepository;

		public WebBlogContextProvider(IBlogRepository blogRepository)
		{
			this.blogRepository = blogRepository;
		}

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
	}
}