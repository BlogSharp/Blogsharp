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
			this.blogContext=new BlogContext{Blog= new Blog{Configuration=new BlogConfiguration{PageSize = 10}}};
			BlogContext.Current = blogContext;
		}

		[TearDown]
		public void TearDown()
		{
			BlogContext.Current = null;
		}

		private BlogContext blogContext;
		private IPostService postService;

		[Test]
		public void Can_read_the_post_with_friendly_title()
		{
			string friendlyTitle = "my-friendly-title";
			var controller = new PostController(this.postService);
			postService
				.Expect(x => x.GetPostByFriendlyTitle(this.blogContext.Blog, friendlyTitle))
				.Return(new Post {Title = "osman"});
			ViewResult view = controller.Read(friendlyTitle) as ViewResult;
			this.postService
				.AssertWasCalled(x => x.GetPostByFriendlyTitle(blogContext.Blog, "my-friendly-title"));
			Assert.NotNull(view.ViewData.Model);
		}

		[Test]
		public void Can_list_the_posts_paged()
		{
			string friendlyTitle = "my-friendly-title";
			var controller = new PostController(this.postService);
			postService
				.Expect(x => x.GetPostsByBlogPaged
					(Arg<Blog>.Is.Equal(this.blogContext.Blog),
					Arg<int>.Is.Anything,
					Arg<int>.Is.Anything))
				.Return(new List<Post>());
			
			ViewResult view = controller.List(0) as ViewResult;
			this.postService
				.AssertWasCalled(x => x.GetPostsByBlogPaged(Arg<Blog>.Is.Equal(blogContext.Blog),
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
			postService.Expect(x => x.GetPostById(Arg<Blog>.Is.Anything,
			                                      Arg<int>.Is.Equal(1))).Return(new Post{FriendlyTitle="m"});
			var actionResult=controller.AddComment(1,postComment) as RedirectToRouteResult;
			actionResult.RouteValues["friendlyTitle"] = "m";
			postService.AssertWasCalled(x => x.AddComment(postComment));

		}
	}
}
