using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSharp.MvcExtensions.ActionResults;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.MvcExtensions.Tests.ActionResults
{
	public class RedirectToRefererResultTests
	{
		public RedirectToRefererResultTests()
		{
			
		}
		[Fact]
		public void Redirects_to_referer_using_HTTP_REFERER_Variable()
		{
			var result=new RedirectToRefererResult();
			
			var context = TestsHelper.PrepareControllerContext();
			context.HttpContext.Request.ServerVariables.Add("HTTP_REFERER","tuna");
			result.ExecuteResult(context);
			context.HttpContext.Response.AssertWasCalled(x => x.Redirect("tuna",true));
		}

	}
}
