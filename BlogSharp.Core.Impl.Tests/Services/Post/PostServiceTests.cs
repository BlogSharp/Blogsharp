namespace BlogSharp.Core.Impl.Tests.Services.Post
{
	using Core.Services.Post;
	using Event.PostEvents;
	using Impl.Services.Post;
	using Model;
	using NUnit.Framework;
	using Persistence.Repositories;
	using Rhino.Mocks;

	[TestFixture]
	public class PostServiceTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.postRepository = MockRepository.GenerateMock<IPostRepository>();
			this.postService = new PostService(this.postRepository);
			this.currentBlog = new Blog {Configuration = new BlogConfiguration {PageSize = 10}};
		}

		#endregion

		private IPostRepository postRepository;
		private IPostService postService;
		private Blog currentBlog;

		[Test]
		public void AddComment_calls_underlying_repository()
		{
			var postComment = new PostComment();
			this.postService.AddComment(postComment);
			this.postRepository.AssertWasCalled(x => x.SaveComment(postComment));
		}

		[Test]
		public void AddPost_calls_underlying_repository_to_save()
		{
			var post = new Model.Post();
			this.postService.AddPost(post);
			this.postRepository.AssertWasCalled(x => x.SavePost(post));
		}

		[Test]
		public void Can_get_post_by_friendlyTitle()
		{
			this.postService.GetPostByFriendlyTitle(this.currentBlog, "friendlyTitle");
			this.postRepository.AssertWasCalled(x => x.GetByTitle(this.currentBlog, "friendlyTitle"));
		}

		[Test]
		public void Can_get_post_by_id()
		{
			this.postService.GetPostById(this.currentBlog, 1);
			this.postRepository.AssertWasCalled(x => x.GetPostById(this.currentBlog, 1));
		}

		[Test]
		public void Can_get_posts_by_blog()
		{
			this.postService.GetPostsByBlog(this.currentBlog);
			this.postRepository.AssertWasCalled(x => x.GetByBlog(this.currentBlog));
		}

		[Test]
		public void Can_get_posts_by_blog_paged()
		{
			this.postService.GetPostsByBlogPaged(this.currentBlog, 0, 10);
			this.postRepository.AssertWasCalled(x => x.GetByBlog(this.currentBlog, 0, 10));
		}

		[Test]
		public void Can_get_posts_by_tag()
		{
			this.postService.GetPostsByTagPaged(this.currentBlog, "friendlyTagName", 0, 10);
			this.postRepository.AssertWasCalled(x => x.GetByTag(this.currentBlog, "friendlyTagName", 0, 10));
		}

		[Test]
		public void Events_raised_for_comment_and_post_actions()
		{
			var post = MockRepository.GenerateStub<Model.Post>();
			var postComment = MockRepository.GenerateStub<PostComment>();
			bool p1 = false, p2 = false, p3 = false, p4 = false;
			bool c1 = false, c2 = false;
			this.postService.CommentAdded += delegate(CommentAddedEventArgs eventArgs)
			                                 	{
			                                 		c1 = true;
			                                 		Assert.AreEqual(postComment, eventArgs.Comment);
			                                 	};
			this.postService.CommentAdding += delegate(CommentAddingEventArgs eventArgs)
			                                  	{
			                                  		c2 = true;
			                                  		Assert.AreEqual(postComment, eventArgs.Comment);
			                                  	};
			this.postService.PostAdding += delegate(PostAddingEventArgs eventArgs)
			                               	{
			                               		p1 = true;
			                               		Assert.AreEqual(post, eventArgs.Post);
			                               	};
			this.postService.PostAdded += delegate(PostAddedEventArgs eventArgs)
			                              	{
			                              		p2 = true;
			                              		Assert.AreEqual(post, eventArgs.Post);
			                              	};
			this.postService.PostRemoved += delegate(PostRemovedEventArgs eventArgs)
			                                	{
			                                		p3 = true;
			                                		Assert.AreEqual(post, eventArgs.Post);
			                                	};
			this.postService.PostRemoving += delegate(PostRemovingEventArgs eventArgs)
			                                 	{
			                                 		p4 = true;
			                                 		Assert.AreEqual(post, eventArgs.Post);
			                                 	};
			this.postService.AddComment(postComment);
			this.postRepository.AssertWasCalled(x => x.SaveComment(postComment));
			this.postService.AddPost(post);
			this.postRepository.AssertWasCalled(x => x.SavePost(post));
			this.postService.RemovePost(post);
			this.postRepository.AssertWasCalled(x => x.DeletePost(post));

			Assert.True(p1);
			Assert.True(p2);
			Assert.True(p3);
			Assert.True(p4);
			Assert.True(c1);
			Assert.True(c2);
		}

		[Test]
		public void RemoveComment_calls_underlyting_repository_to_delete()
		{
			var comment = new PostComment();
			this.postService.RemoveComment(comment);
			this.postRepository.AssertWasCalled(x => x.DeleteComment(comment));
		}

		[Test]
		public void RemovePost_calls_underlyting_repository_to_delete()
		{
			var post = new Model.Post();
			this.postService.RemovePost(post);
			this.postRepository.AssertWasCalled(x => x.DeletePost(post));
		}

		[Test]
		public void Repository_is_not_called_if_event_is_cancelled()
		{
			var post = MockRepository.GenerateStub<Model.Post>();
			var postComment = MockRepository.GenerateStub<PostComment>();

			this.postService.CommentAdded += delegate { throw new AssertionException("Shouldn't be called"); };
			this.postService.CommentAdding += x => x.Cancel = true;
			this.postService.PostAdding += x => x.Cancel = true;
			this.postService.PostAdded += delegate { throw new AssertionException("Shouldn't be called"); };
			this.postService.PostRemoved += delegate { throw new AssertionException("Shouldn't be called"); };
			this.postService.PostRemoving += x => x.Cancel = true;
			this.postService.AddComment(postComment);
			this.postRepository.AssertWasNotCalled(x => x.SaveComment(postComment));
			this.postService.AddPost(post);
			this.postRepository.AssertWasNotCalled(x => x.SavePost(post));
			this.postService.RemovePost(post);
			this.postRepository.AssertWasNotCalled(x => x.DeletePost(post));
		}
	}
}