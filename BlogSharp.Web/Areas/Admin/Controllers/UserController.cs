using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BlogSharp.Web.Areas.Admin.Controllers
{
	public class UserController : Controller
	{
		public ActionResult Index()
		{
			return View("List");
		}
	}
}
