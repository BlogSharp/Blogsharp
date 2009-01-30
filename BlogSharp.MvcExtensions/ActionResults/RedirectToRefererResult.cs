using System.Web.Mvc;

namespace BlogSharp.MvcExtensions.ActionResults
{
	public class RedirectToRefererResult : ActionResult
	{
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Redirect(context.HttpContext.Request.ServerVariables["HTTP_REFERER"], true);
		}
	}
}