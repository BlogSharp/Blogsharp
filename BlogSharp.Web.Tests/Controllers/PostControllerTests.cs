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
			this.postService = MockRepository.GenerateMock<IPostService>();
			this.blogContextProvider = MockRepository.GenerateMock<BlogContextProvider>();
			this.blog = new Blog
			            	{
			            		Configuration = new BlogConfiguration {PageSize = 10}
			            	};
			this.blogContextProvider.Expect(x => x.GetCurrentBlogContext())
				.Return(new BlogContext {Blog = this.blog})
				.Repeat.Any();
			this.controller = new PostController(this.postService);
			BlogContextProvider.Current = this.blogContextProvider;
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
			this.postService.Expect(x => x.GetPostById(this.blog, 1))
				.Return(new Post {FriendlyTitle = "m"});
			var actionResult = this.controller.AddComment(1, postComment) as RedirectToRouteResult;
			Assert.That(actionResult, Is.Not.Null);
			this.postService.AssertWasCalled(x => x.AddComment(postComment));
		}

		[Test]
		public void Can_list_posts_with_certain_tag()
		{
			var postList = new List<Post>();
			this.postService.Expect(x => x.GetPostsByTagPaged(this.blog, "myTag", 0, 10)).Return(postList);
			var result = this.controller.ListByTag("myTag", 1) as ViewResult;
			var data = result.ViewData.Model;
			Assert.That(data, Is.Not.Null);
		}

		[Test]
		public void Can_list_the_posts_paged()
		{
			this.postService
				.Expect(x => x.GetPostsByBlogPaged(
				             	Arg<Blog>.Is.Equal(this.blog),
				             	Arg<int>.Is.Anything,
				             	Arg<int>.Is.Anything))
				.Return(new List<Post>());

			ViewResult view = this.controller.List(0) as ViewResult;
			this.postService.AssertWasCalled(x => x.GetPostsByBlogPaged(
			                                      	Arg<Blog>.Is.Equal(this.blog),
			                                      	Arg<int>.Is.Anything,
			                                      	Arg<int>.Is.NotEqual(0)));
			Assert.NotNull(view.ViewData.Model);
			Assert.That(view.ViewData.Model as IList<Post>, Is.Not.Null);
		}

		[Test]
		public void Can_read_the_post_with_friendly_title()
		{
			string friendlyTitle = "my-friendly-title";

			this.postService
				.Expect(x => x.GetPostByFriendlyTitle(this.blog, friendlyTitle))
				.Return(new Post {Title = "osman"});
			ViewResult view = this.controller.Read(friendlyTitle) as ViewResult;
			this.postService
				.AssertWasCalled(x => x.GetPostByFriendlyTitle(this.blog, "my-friendly-title"));
			Assert.NotNull(view.ViewData.Model);
		}
	}
}