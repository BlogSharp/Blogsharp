using System.Web.Mvc;
using Xunit;
using BlogSharp.Web.Controllers;

namespace BlogSharp.Web.Tests.Controllers
{
	public class HomeControllerTests
	{
		public class Index
		{
			[Fact]
			public void ReturnsViewResultWithDefaultViewName()
			{
				var controller = new HomeController(null);
				var result = controller.Index();
				var viewResult = Assert.IsType<ViewResult>(result);
				Assert.Null(viewResult.ViewName);
			}

			[Fact]
			public void SetsViewDataWithNoModel()
			{
				var controller = new HomeController(null);
				var result = (ViewResult)controller.Index();
				Assert.Equal("Home Page", result.ViewData["Title"]);
				Assert.Equal("Welcome to ASP.NET MVC!", result.ViewData["Message"]);
				Assert.Null(result.ViewData.Model);
			}
		}

		public class About
		{
			[Fact]
			public void ReturnsViewResultWithDefaultViewName()
			{
				var controller = new HomeController(null);
				var result = controller.About();
				var viewResult = Assert.IsType<ViewResult>(result);
				Assert.Null(viewResult.ViewName);
			}

			[Fact]
			public void SetsViewDataWithNoModel()
			{
				var controller = new HomeController(null);
				var result = (ViewResult)controller.About();
				Assert.Equal("About Page", result.ViewData["Title"]);
				Assert.Null(result.ViewData.Model);
			}
		}
	}
}
