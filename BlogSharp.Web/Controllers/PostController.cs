using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BlogSharp.Core.Services.Post;
using BlogSharp.Core.Web;
using BlogSharp.Model;

namespace BlogSharp.Web.Controllers
{
	[HandleError]
	public class PostController : Controller
	{
		public PostController(IPostService postService)
		{
			this.postService = postService;
		}

		private readonly IPostService postService;
		public ActionResult List(int page)
		{
			var posts = postService.GetPostsByBlog(BlogContext.Current.Blog);
			return View(posts);
		}

		public ActionResult Read(string friendlyTitle)
		{
			var post = postService.GetPostByFriendlyTitle(friendlyTitle);
			return View(post);
		}
	}
}
