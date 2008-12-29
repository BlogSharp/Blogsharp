using System.Web.Mvc;

namespace BlogSharp.Web.Areas.Admin.Controllers
{
	public class BlogController : Controller
	{
		public ActionResult Index()
		{
			return View("List");
		}

		public ActionResult Detail(int? id)
		{
			return View("Detail");
		}
	}
}
