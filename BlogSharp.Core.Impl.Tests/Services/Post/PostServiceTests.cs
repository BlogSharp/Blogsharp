using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Event.PostEvents;
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
			container.Expect(x => x.Resolve<IRepository<IPost>>()).Return(this.postRepository).Repeat.Any();
			container.Expect(x => x.Resolve<IRepository<IPostComment>>()).Return(this.postCommentRepository).Repeat.Any();
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
			postRepository.AssertWasCalled(x=>x.Save(post));
		}

		[Fact]
		public void AddComment_calls_underlying_repository()
		{
			var postComment = GetEntityFactory<IPostComment>().Create();
			postService.AddComment(postComment);
			postCommentRepository.AssertWasCalled(x => x.Save(postComment));

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

		[Fact]
		public void Events_raised_for_comment_and_post_actions()
		{
			var post = MockRepository.GenerateStub<IPost>();
			var postComment = MockRepository.GenerateStub<IPostComment>();
			bool p1 = false, p2 = false, p3 = false, p4 = false;
			bool c1 = false, c2 = false;
			postService.CommentAdded += delegate(IPostService service, CommentAddedEventArgs eventArgs)
			                            	{
			                            		c1 = true;
			                            		Assert.Equal(postComment, eventArgs.Comment);
			                            	};
			postService.CommentAdding += delegate(IPostService service, CommentAddingEventArgs eventArgs)
			                             	{
			                             		c2 = true;
			                             		Assert.Equal(postComment, eventArgs.Comment);
			                             	};


			postService.PostAdding += delegate(IPostService service, PostAddingEventArgs eventArgs)
			                          	{
			                          		p1 = true;
			                          		Assert.Equal(post, eventArgs.Post);
			                          	};
			postService.PostAdded += delegate(IPostService service, PostAddedEventArgs eventArgs)
			                         	{
			                         		p2 = true;
			                         		Assert.Equal(post, eventArgs.Post);
			                         	};
			postService.PostRemoved += delegate(IPostService service, PostRemovedEventArgs eventArgs)
			                           	{
			                           		p3 = true;
			                           		Assert.Equal(post, eventArgs.Post);
			                           	};
			postService.PostRemoving += delegate(IPostService service, PostRemovingEventArgs eventArgs)
			                            	{
			                            		p4 = true;
			                            		Assert.Equal(post, eventArgs.Post);
			                            	};
			postService.AddComment(postComment);
			postService.AddPost(post);
			postService.RemovePost(post);

			Assert.True(p1);
			Assert.True(p2);
			Assert.True(p3);
			Assert.True(p4);
			Assert.True(c1);
			Assert.True(c2);
		}
	}
}
