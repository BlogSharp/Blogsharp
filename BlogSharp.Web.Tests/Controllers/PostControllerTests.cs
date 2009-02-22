namespace BlogSharp.Web.Tests.Controllers
{
	using System.Collections.Generic;
	using System.Web.Mvc;
	using Core.Impl.Web;
	using Core.Services.Post;
	using Model;
	using NUnit.Framework;
	using Rhino.Mocks;
	using Web.Controllers;

	[TestFixture]
	public class PostControllerTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			postService = MockRepository.GenerateMock<IPostService>();
			blogContextProvider = MockRepository.GenerateMock<BlogContextProvider>();
			blog = new Blog
			       	{
			       		Configuration = new BlogConfiguration {PageSize = 10}
			       	};
			blogContextProvider.Expect(x => x.GetCurrentBlogContext())
				.Return(new BlogContext {Blog = blog})
				.Repeat.Any();
			controller = new PostController(postService);
			BlogContextProvider.Current = blogContextProvider;
		}

		[TearDown]
		public void TearDown()
		{
			BlogContextProvider.Current = null;
		}

		#endregion

		private Blog blog;
		private BlogContextProvider blogContextProvider;
		private IPostService postService;
		private PostController controller;

		[Test]
		public void Can_insert_post_comment()
		{
			var postComment = new PostComment();
			postService.Expect(x => x.GetPostById(blog, 1))
				.Return(new Post {FriendlyTitle = "m"});
			var actionResult = controller.AddComment(1, postComment) as RedirectToRouteResult;
			Assert.That(actionResult, Is.Not.Null);
			postService.AssertWasCalled(x => x.AddComment(postComment));
		}

		[Test]
		public void Can_list_posts_with_certain_tag()
		{
			var postList = new List<Post>();
			postService.Expect(x => x.GetPostsByTagPaged(blog, "myTag", 0, 10)).Return(postList);
			var result = controller.ListByTag("myTag", 1) as ViewResult;
			var data = result.ViewData.Model;
			Assert.That(data, Is.Not.Null);
		}

		[Test]
		public void Can_list_the_posts_paged()
		{
			postService
				.Expect(x => x.GetPostsByBlogPaged(
				             	Arg<Blog>.Is.Equal(blog),
				             	Arg<int>.Is.Anything,
				             	Arg<int>.Is.Anything))
				.Return(new List<Post>());

			ViewResult view = controller.List(0) as ViewResult;
			postService.AssertWasCalled(x => x.GetPostsByBlogPaged(
			                                 	Arg<Blog>.Is.Equal(blog),
			                                 	Arg<int>.Is.Anything,
			                                 	Arg<int>.Is.NotEqual(0)));
			Assert.NotNull(view.ViewData.Model);
			Assert.That(view.ViewData.Model as IList<Post>, Is.Not.Null);
		}

		[Test]
		public void Can_read_the_post_with_friendly_title()
		{
			string friendlyTitle = "my-friendly-title";

			postService
				.Expect(x => x.GetPostByFriendlyTitle(blog, friendlyTitle))
				.Return(new Post {Title = "osman"});
			ViewResult view = controller.Read(friendlyTitle) as ViewResult;
			postService
				.AssertWasCalled(x => x.GetPostByFriendlyTitle(blog, "my-friendly-title"));
			Assert.NotNull(view.ViewData.Model);
		}
	}
}