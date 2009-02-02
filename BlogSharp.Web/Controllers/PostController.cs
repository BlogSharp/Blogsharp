using System.Web.Mvc;
using BlogSharp.Core.Impl.Web;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;
using Spark.Web.Mvc;

namespace BlogSharp.Web.Controllers
{
	[HandleError]
	public class PostController : BlogSharpController
	{
		private readonly IPostService postService;

		public PostController(IPostService postService)
		{
			this.postService = postService;
		}

		public ActionResult List(int page)
		{
			var posts = postService.GetPostsByBlogPaged(CurrentBlog, 0,CurrentBlog.Configuration.PageSize);
			return View(posts);
		}

		public ActionResult Read(string friendlyTitle)
		{
			var post = postService.GetPostByFriendlyTitle(CurrentBlog, friendlyTitle);
			return View(post);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult AddComment(int postId,PostComment comment)
		{
			var post = postService.GetPostById(CurrentBlog,postId);
			post.AddComment(comment);
			postService.AddComment(comment);
			return RedirectToAction("Read", new {post.FriendlyTitle});
		}
	}
}