// <copyright file="TestsHelper.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.MvcExtensions.Tests
{
	using System.Collections.Specialized;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using Rhino.Mocks;

	/// <summary>
	/// Class to help the tests.
	/// </summary>
	internal class TestsHelper
	{
		/// <summary>
		/// Prepares the controller context.
		/// </summary>
		/// <returns>The controller context.</returns>
		public static ControllerContext PrepareControllerContext()
		{
			var requestContext = PrepareRequestContext();
			var controllerBase = MockRepository.GenerateStub<ControllerBase>();
			var controllerContext = new ControllerContext(requestContext, controllerBase);
			return controllerContext;
		}

		/// <summary>
		/// Prepares the request context.
		/// </summary>
		/// <returns>The request context.</returns>
		public static RequestContext PrepareRequestContext()
		{
			var httpResponse = MockRepository.GenerateStub<HttpResponseBase>();
			var httpRequest = MockRepository.GenerateStub<HttpRequestBase>();
			var serverVariables = new NameValueCollection();
			httpRequest.Expect(x => x.ServerVariables).Return(serverVariables).Repeat.Any();
			var httpContext = MockRepository.GenerateStub<HttpContextBase>();
			httpContext.Expect(x => x.Response).Return(httpResponse).Repeat.Any();
			httpContext.Expect(x => x.Request).Return(httpRequest).Repeat.Any();

			var requestContext = MockRepository.GenerateStub<RequestContext>(httpContext, new RouteData());
			return requestContext;
		}
	}
}