using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BlogSharp.Core.Services.Post;

namespace BlogSharp.Web.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public HomeController(IPostService postService)
		{
			this.postService = postService;
		}

		private readonly IPostService postService;
		public ActionResult Index()
		{
			ViewData["Title"] = "Home Page";
			ViewData["Message"] = "Welcome to ASP.NET MVC!";
			var post=postService.GetPostById(1);
			return View();
		}

		public ActionResult About()
		{
			ViewData["Title"] = "About Page";

			return View();
		}
	}
}
