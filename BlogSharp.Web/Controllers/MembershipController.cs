using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace BlogSharp.Web.Controllers
{

	[HandleError]
	[OutputCache(Location = OutputCacheLocation.None)]
	public class MembershipController : Controller
	{
		[Authorize]
		public ActionResult ChangePassword()
		{
			ViewData["Title"] = "Change Password";
			return View();
		}
	}
}
