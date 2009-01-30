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

		public ActionResult Index()
		{
			return RedirectToAction("List", "Post", new {page = 0});
		}

		public ActionResult List(int page)
		{
			var posts = postService.GetPostsByBlog(BlogContext.Current.Blog);
			return View(posts);
		}

		public ActionResult Read(string friendlyTitle)
		{
			var post = postService.GetPostByFriendlyTitle(BlogContext.Current.Blog, friendlyTitle);
			return View(post);
		}

		public ActionResult ShowCart()
		{
			return new JavascriptViewResult {ViewName = "_CommentList"};
		}
	}
}