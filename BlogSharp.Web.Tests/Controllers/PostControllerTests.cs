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
using Xunit;

namespace BlogSharp.Web.Tests.Controllers
{
	public class PostControllerTests:IDisposable
	{
		public PostControllerTests()
		{
			this.postService = MockRepository.GenerateMock<IPostService>();
			this.blogContext=new BlogContext{Blog= new Blog()};
			BlogContext.Current = blogContext;
		}

		public void Dispose()
		{
			BlogContext.Current = null;
		}

		private BlogContext blogContext;
		private IPostService postService;

		[Fact]
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

		[Fact]
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
															Arg<int>.Is.Anything));
			Assert.NotNull(view.ViewData.Model);
			Assert.IsAssignableFrom(typeof (IList<Post>), view.ViewData.Model);
		}
	}
}
