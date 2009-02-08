using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BlogSharp.Core.Impl.Web;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;
using BlogSharp.Web.Controllers;
using Rhino.Mocks;
using NUnit.Framework;

namespace BlogSharp.Web.Tests.Controllers
{
	[TestFixture]
	public class PostControllerTests
	{
		[SetUp]
		public void SetUp()
		{
			this.postService = MockRepository.GenerateMock<IPostService>();
			this.blogContextProvider = MockRepository.GenerateMock<BlogContextProvider>();
			this.blog = new Blog
			            	{
			            		Configuration =
			            			new BlogConfiguration {PageSize = 10}
			            	};
			this.blogContextProvider.Expect(x => x.GetCurrentBlogContext())
				.Return(new BlogContext{Blog =blog}).Repeat.Any();
			BlogContextProvider.Current = this.blogContextProvider;
		}

		[TearDown]
		public void TearDown()
		{
			BlogContextProvider.Current = null;
		}

		private Blog blog;
		private BlogContextProvider blogContextProvider;
		private IPostService postService;

		[Test]
		public void Can_read_the_post_with_friendly_title()
		{
			string friendlyTitle = "my-friendly-title";
			var controller = new PostController(this.postService);
			postService
				.Expect(x => x.GetPostByFriendlyTitle(blog, friendlyTitle))
				.Return(new Post {Title = "osman"});
			ViewResult view = controller.Read(friendlyTitle) as ViewResult;
			this.postService
				.AssertWasCalled(x => x.GetPostByFriendlyTitle(blog, "my-friendly-title"));
			Assert.NotNull(view.ViewData.Model);
		}

		[Test]
		public void Can_list_the_posts_paged()
		{
			string friendlyTitle = "my-friendly-title";
			var controller = new PostController(this.postService);
			postService
				.Expect(x => x.GetPostsByBlogPaged
					(Arg<Blog>.Is.Equal(blog),
					Arg<int>.Is.Anything,
					Arg<int>.Is.Anything))
				.Return(new List<Post>());
			
			ViewResult view = controller.List(0) as ViewResult;
			this.postService
				.AssertWasCalled(x => x.GetPostsByBlogPaged(Arg<Blog>.Is.Equal(blog),
				                                            Arg<int>.Is.Anything, 
															Arg<int>.Is.NotEqual(0)));
			Assert.NotNull(view.ViewData.Model);
			Assert.That(view.ViewData.Model as IList<Post>!=null);
		}

		[Test]
		public void Can_insert_post_comment()
		{
			var postComment = new PostComment();
			var controller = new PostController(postService);
			postService.Expect(x => x.GetPostById(blog,
			                                      1)).Return(new Post {FriendlyTitle = "m"});
			var actionResult=controller.AddComment(1,postComment) as RedirectToRouteResult;
			postService.AssertWasCalled(x => x.AddComment(postComment));
		}

		[Test]
		public void Can_list_posts_with_certain_tag()
		{
			var controller = new PostController(postService);
			var postList = new List<Post>();
			postService.Expect(x => x.GetPostsByTagPaged(blog, "myTag", 0, 10)).Return(postList);
			var result = controller.ListByTag("myTag", 1) as ViewResult;
			var data = result.ViewData.Model;
			Assert.That(data,Is.Not.Null);;
		}
	}
}
