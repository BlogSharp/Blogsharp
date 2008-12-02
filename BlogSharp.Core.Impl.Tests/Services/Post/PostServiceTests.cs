using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.Services.Post;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;
using Castle.Windsor;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.Post
{
	public class PostServiceTests:BaseTest
	{
		public PostServiceTests()
		{
			this.postService = new PostService();
			this.postRepository = MockRepository.GenerateMock<IRepository<IPost>>();
			this.postCommentRepository = MockRepository.GenerateMock<IRepository<IPostComment>>();
			IWindsorContainer container = MockRepository.GenerateStub<IWindsorContainer>();
			container.Expect(x => x.Resolve<IRepository<IPost>>()).Return(this.postRepository);
			container.Expect(x => x.Resolve<IRepository<IPostComment>>()).Return(this.postCommentRepository);
			DI.SetContainer(container);
		}
		
		private readonly IRepository<IPost> postRepository;
		private readonly IRepository<IPostComment> postCommentRepository;
		private readonly IPostService postService;

		[Fact]
		public void AddPost_calls_underlying_repository_to_save()
		{
			var post = GetEntityFactory<IPost>().Create();
			postService.AddPost(post);
			postRepository.AssertWasCalled(x=>x.Add(post));
		}

		[Fact]
		public void AddComment_calls_underlying_repository()
		{
			var postComment = GetEntityFactory<IPostComment>().Create();
			postService.AddComment(postComment);
			postCommentRepository.AssertWasCalled(x => x.Add(postComment));

		}

		[Fact]
		public void RemovePost_calls_underlyting_repository_to_delete()
		{
			var post = GetEntityFactory<IPost>().Create();
			postService.RemovePost(post);
			postRepository.AssertWasCalled(x => x.Remove(post));
		}


		[Fact]
		public void RemoveComment_calls_underlyting_repository_to_delete()
		{
			var post = GetEntityFactory<IPostComment>().Create();
			postService.RemoveComment(post);
			postCommentRepository.AssertWasCalled(x => x.Remove(post));

		}
	}
}
