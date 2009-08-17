namespace BlogSharp.MvcExtensions.ActionResults
{
	using System.Web.Mvc;

	/// <summary>
	/// Redirects to the referer page.
	/// </summary>
	public class RedirectToRefererResult : ActionResult
	{
		/// <summary>
		/// Executes the redirection.
		/// </summary>
		/// <param name="context">The execution context.</param>
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.Redirect(context.HttpContext.Request.ServerVariables["HTTP_REFERER"], true);
		}
	}
}