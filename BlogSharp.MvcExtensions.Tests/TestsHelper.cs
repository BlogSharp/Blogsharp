namespace BlogSharp.MvcExtensions.Tests
{
	using System.Collections.Specialized;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using Rhino.Mocks;

	internal class TestsHelper
	{
		public static ControllerContext PrepareControllerContext()
		{
			var requestContext = PrepareRequestContext();
			var controllerBase = MockRepository.GenerateStub<ControllerBase>();
			var controllerContext = new ControllerContext(requestContext, controllerBase);
			return controllerContext;
		}

		public static RequestContext PrepareRequestContext()
		{
			var httpResponse = MockRepository.GenerateStub<HttpResponseBase>();
			var httpRequest = MockRepository.GenerateStub<HttpRequestBase>();
			var serverVariables = new NameValueCollection();
			httpRequest.Expect(x => x.ServerVariables).Return(serverVariables).Repeat.Any();
			var httpContext = MockRepository.GenerateStub<HttpContextBase>();
			httpContext.Expect(x => x.Response).Return(httpResponse).Repeat.Any();
			httpContext.Expect(x => x.Request).Return(httpRequest).Repeat.Any();
			;
			var requestContext = MockRepository.GenerateStub<RequestContext>(httpContext, new RouteData());
			return requestContext;
		}
	}
}