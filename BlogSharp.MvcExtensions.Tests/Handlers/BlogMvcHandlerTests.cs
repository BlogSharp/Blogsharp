namespace BlogSharp.MvcExtensions.Tests.Handlers
{
	using System;
	using System.Reflection;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using MvcExtensions.Handlers;
	using NUnit.Framework;
	using Rhino.Mocks;

	public class DummyController : ControllerBase
	{
		public bool WasCalled { get; set; }

		protected override void Execute(RequestContext requestContext)
		{
			this.WasCalled = true;
			base.Execute(requestContext);
		}

		protected override void ExecuteCore()
		{
		}
	}

	public class DummyController2 : ControllerBase
	{
		protected override void Execute(RequestContext requestContext)
		{
			throw new Exception();
			//base.Execute(requestContext);
		}


		protected override void ExecuteCore()
		{
		}
	}

	[TestFixture]
	public class BlogMvcHandlerTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.context = TestsHelper.PrepareRequestContext();
			this.handler = new BlogMvcHandler(this.context);
			this.context.RouteData.Values["controller"] = typeof (Controller);
			this.methodInfo = this.handler.GetType()
				.GetMethod("ProcessRequest", BindingFlags.NonPublic | BindingFlags.Instance, null,
				           new[] {typeof (HttpContextBase)}, null);
			this.dummyFactory = MockRepository.GenerateStub<IExtendedControllerFactory>();
			ControllerBuilder.Current.SetControllerFactory(this.dummyFactory);
		}

		#endregion

		private RequestContext context;
		private IExtendedControllerFactory dummyFactory;
		private MvcHandler handler;
		private MethodInfo methodInfo;

		[Test]
		public void Can_release_when_exception_occurs()
		{
			var dummyController2 = new DummyController2();
			this.dummyFactory.Expect(x => x.CreateController(Arg<RequestContext>.Is.Anything,
			                                                 Arg<Type>.Is.Equal(typeof (Controller))))
				.Return(dummyController2)
				.Repeat.Any();
			ControllerBuilder.Current.SetControllerFactory(this.dummyFactory);
			try
			{
				this.methodInfo.Invoke(this.handler, new object[] {this.context.HttpContext});
			}
			catch
			{
			}
			this.dummyFactory.AssertWasCalled(
				x => x.CreateController(Arg<RequestContext>.Is.Anything, Arg<Type>.Is.Equal(typeof (Controller))));
			this.dummyFactory.AssertWasCalled(x => x.ReleaseController(dummyController2));
		}

		[Test]
		public void Factory_should_resolve_given_controller_with_its_type()
		{
			var dummyController = new DummyController();
			this.dummyFactory.Expect(x => x.CreateController(Arg<RequestContext>.Is.Anything,
			                                                 Arg<Type>.Is.Equal(typeof (Controller))))
				.Return(dummyController)
				.Repeat.Any();

			this.methodInfo.Invoke(this.handler, new object[] {this.context.HttpContext});
			this.dummyFactory.AssertWasCalled(
				x => x.CreateController(Arg<RequestContext>.Is.Anything, Arg<Type>.Is.Equal(typeof (Controller))));
			Assert.True(dummyController.WasCalled);
		}
	}
}