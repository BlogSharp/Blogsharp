namespace BlogSharp.MvcExtensions.Tests.ActionResults
{
	using MvcExtensions.ActionResults;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class RedirectToRefererResultTests
	{
		[Test]
		public void Redirects_to_referer_using_HTTP_REFERER_Variable()
		{
			var result = new RedirectToRefererResult();

			var context = TestsHelper.PrepareControllerContext();
			context.HttpContext.Request.ServerVariables.Add("HTTP_REFERER", "tuna");
			result.ExecuteResult(context);
			context.HttpContext.Response.AssertWasCalled(x => x.Redirect("tuna", true));
		}
	}
}