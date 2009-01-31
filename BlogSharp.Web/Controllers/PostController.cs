using System.Web.Mvc;
using BlogSharp.Core.Impl.Web;
using BlogSharp.Core.Services.Post;
using Spark.Web.Mvc;

namespace BlogSharp.Web.Controllers
{
	[HandleError]
	public class PostController : Controller
	{
		private readonly IPostService postService;

		public PostController(IPostService postService)
		{
			this.postService = postService;
		}

		public ActionResult List(int page)
		{
			var posts = postService.GetPostsByBlogPaged(BlogContext.Current.Blog,0,0);
			return View(posts);
		}

		public ActionResult Read(string friendlyTitle)
		{
			var post = postService.GetPostByFriendlyTitle(BlogContext.Current.Blog, friendlyTitle);
			return View(post);
		}
	}
}