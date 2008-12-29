using System;
using System.Web.Mvc;
using BlogSharp.Core;
using BlogSharp.Core.Services.Model;
using BlogSharp.Model;

namespace BlogSharp.Web.Areas.Admin.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService blogService;

		public BlogController()
		{
			blogService = DI.Container.Resolve<IBlogService>();
		}

		public ActionResult Index()
		{
			var blogs = blogService.GetAllBlogs();
			return View("List", blogs);
		}

		public ActionResult Detail(Guid? id)
		{
			var blog = id.HasValue ? blogService.GetById(id.Value) : DI.Container.Resolve<IBlog>();

			return View("Detail", blog);
		}

		public ActionResult Save(Guid id, string name)
		{
			var blog = DI.Container.Resolve<IBlog>();
			blog.Id = id;
			blog.Name = name;
			blogService.SaveBlog(blog);
			return RedirectToAction("Index");
		}
	}
}
