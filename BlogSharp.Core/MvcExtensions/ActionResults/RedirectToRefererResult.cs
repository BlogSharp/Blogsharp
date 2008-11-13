using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BlogSharp.Core.MvcExtensions.ActionResults
{
	/// <summary>
	/// Redirects to the referer
	/// </summary>
	public class RedirectToRefererResult : ActionResult
	{
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Redirect(context.HttpContext.Request.ServerVariables["HTTP_REFERER"], true);
		}

	}
}
