namespace BlogSharp.Web.Controllers
{
	using System.Web.Mvc;
	using Core.Impl.Web;
	using Model;

	public abstract class BlogSharpController : Controller
	{
		protected virtual Blog CurrentBlog
		{
			get { return CurrentBlogContext.Blog; }
		}

		protected virtual BlogContext CurrentBlogContext
		{
			get { return BlogContextProvider.Current.GetCurrentBlogContext(); }
		}
	}
}