using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Core.Impl.Services.Post;
using BlogSharp.Core.Persistence.Repositories;
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
			this.postRepository = MockRepository.GenerateMock<IPostRepository>();
			this.postService = new PostService(this.postRepository);
		}
		
		private readonly IPostRepository postRepository;
		private readonly IPostService postService;

		[Fact]
		public void AddPost_calls_underlying_repository_to_save()
		{
			var post = GetEntityFactory<IPost>().Create();
			postService.AddPost(post);
			postRepository.AssertWasCalled(x=>x.SavePost(post));
		}

		[Fact]
		public void AddComment_calls_underlying_repository()
		{
			var postComment = GetEntityFactory<IPostComment>().Create();
			postService.AddComment(postComment);
			postRepository.AssertWasCalled(x => x.SaveComment(postComment));

		}

		[Fact]
		public void RemovePost_calls_underlyting_repository_to_delete()
		{
			var post = GetEntityFactory<IPost>().Create();
			postService.RemovePost(post);
			postRepository.AssertWasCalled(x => x.DeletePost(post));
		}

		[Fact]
		public void RemoveComment_calls_underlyting_repository_to_delete()
		{
			var comment = GetEntityFactory<IPostComment>().Create();
			postService.RemoveComment(comment);
			postRepository.AssertWasCalled(x => x.DeleteComment(comment));

		}

		[Fact]
		public void Events_raised_for_comment_and_post_actions()
		{
			var post = MockRepository.GenerateStub<IPost>();
			var postComment = MockRepository.GenerateStub<IPostComment>();
			bool p1 = false, p2 = false, p3 = false, p4 = false;
			bool c1 = false, c2 = false;
			postService.CommentAdded += delegate(CommentAddedEventArgs eventArgs)
			                            {
			                            	c1 = true;
			                            	Assert.Equal(postComment, eventArgs.Comment);
			                            };
			postService.CommentAdding += delegate(CommentAddingEventArgs eventArgs)
			                            {
			                            	c2 = true;
			                            	Assert.Equal(postComment, eventArgs.Comment);
			                            };
			postService.PostAdding += delegate(PostAddingEventArgs eventArgs)
			                          	{
			                          		p1 = true;
			                          		Assert.Equal(post, eventArgs.Post);
			                          	};
			postService.PostAdded += delegate(PostAddedEventArgs eventArgs)
			                         	{
			                         		p2 = true;
			                         		Assert.Equal(post, eventArgs.Post);
			                         	};
			postService.PostRemoved += delegate(PostRemovedEventArgs eventArgs)
			                           	{
			                           		p3 = true;
			                           		Assert.Equal(post, eventArgs.Post);
			                           	};
			postService.PostRemoving += delegate(PostRemovingEventArgs eventArgs)
			                            {
			                            	p4 = true;
			                            	Assert.Equal(post, eventArgs.Post);
			                            };
			postService.AddComment(postComment);
			postRepository.AssertWasCalled(x=>x.SaveComment(postComment));
			postService.AddPost(post);
			postRepository.AssertWasCalled(x => x.SavePost(post));
			postService.RemovePost(post);
			postRepository.AssertWasCalled(x => x.DeletePost(post));

			Assert.True(p1);
			Assert.True(p2);
			Assert.True(p3);
			Assert.True(p4);
			Assert.True(c1);
			Assert.True(c2);
		}

		[Fact]
		public void Repository_is_not_called_if_event_is_cancelled()
		{
			var post = MockRepository.GenerateStub<IPost>();
			var postComment = MockRepository.GenerateStub<IPostComment>();

			postService.CommentAdded += delegate
			                            	{
			                            		throw new Xunit.Sdk.AssertException("Shouldn't be called");
			                            	};
			postService.CommentAdding += x => x.Cancel = true;
			postService.PostAdding += x => x.Cancel = true;
			postService.PostAdded += delegate
			                         	{
			                         		throw new Xunit.Sdk.AssertException("Shouldn't be called");
			                         	};
			postService.PostRemoved += delegate
			                         	{
			                         		throw new Xunit.Sdk.AssertException("Shouldn't be called");
			                         	};
			postService.PostRemoving += x => x.Cancel = true;
			postService.AddComment(postComment);
			postRepository.AssertWasNotCalled(x => x.SaveComment(postComment));
			postService.AddPost(post);
			postRepository.AssertWasNotCalled(x => x.SavePost(post));
			postService.RemovePost(post);
			postRepository.AssertWasNotCalled(x => x.DeletePost(post));
		}
	}
}
