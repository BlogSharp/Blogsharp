using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Core.Impl.Services.Post;
using BlogSharp.Core.Impl.Web;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace BlogSharp.Core.Impl.Tests.Services.Post
{
    [TestFixture]
    public class PostServiceTests
    {
        private IPostRepository postRepository;
        private IPostService postService;

        [SetUp]
        public void SetUp()
        {
            postRepository = MockRepository.GenerateMock<IPostRepository>();
            postService = new PostService(postRepository);
            var blogContext = new BlogContext { Blog = new Blog { Configuration = new BlogConfiguration { PageSize = 10 } } };
            BlogContext.Current = blogContext;
        }

        [Test]
        public void AddPost_calls_underlying_repository_to_save()
        {
            var post = new Model.Post();
            postService.AddPost(post);
            postRepository.AssertWasCalled(x => x.SavePost(post));
        }

        [Test]
        public void AddComment_calls_underlying_repository()
        {
            var postComment = new PostComment();
            postService.AddComment(postComment);
            postRepository.AssertWasCalled(x => x.SaveComment(postComment));
        }

        [Test]
        public void RemovePost_calls_underlyting_repository_to_delete()
        {
            var post = new Model.Post();
            postService.RemovePost(post);
            postRepository.AssertWasCalled(x => x.DeletePost(post));
        }

        [Test]
        public void RemoveComment_calls_underlyting_repository_to_delete()
        {
            var comment = new PostComment();
            postService.RemoveComment(comment);
            postRepository.AssertWasCalled(x => x.DeleteComment(comment));
        }

        [Test]
        public void Events_raised_for_comment_and_post_actions()
        {
            var post = MockRepository.GenerateStub<Model.Post>();
            var postComment = MockRepository.GenerateStub<PostComment>();
            bool p1 = false, p2 = false, p3 = false, p4 = false;
            bool c1 = false, c2 = false;
            postService.CommentAdded += delegate(CommentAddedEventArgs eventArgs)
                                            {
                                                c1 = true;
                                                Assert.AreEqual(postComment, eventArgs.Comment);
                                            };
            postService.CommentAdding += delegate(CommentAddingEventArgs eventArgs)
                                            {
                                                c2 = true;
                                                Assert.AreEqual(postComment, eventArgs.Comment);
                                            };
            postService.PostAdding += delegate(PostAddingEventArgs eventArgs)
                                        {
                                            p1 = true;
                                            Assert.AreEqual(post, eventArgs.Post);
                                        };
            postService.PostAdded += delegate(PostAddedEventArgs eventArgs)
                                        {
                                            p2 = true;
                                            Assert.AreEqual(post, eventArgs.Post);
                                        };
            postService.PostRemoved += delegate(PostRemovedEventArgs eventArgs)
                                        {
                                            p3 = true;
                                            Assert.AreEqual(post, eventArgs.Post);
                                        };
            postService.PostRemoving += delegate(PostRemovingEventArgs eventArgs)
                                            {
                                                p4 = true;
                                                Assert.AreEqual(post, eventArgs.Post);
                                            };
            postService.AddComment(postComment);
            postRepository.AssertWasCalled(x => x.SaveComment(postComment));
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

        [Test]
        public void Repository_is_not_called_if_event_is_cancelled()
        {
            var post = MockRepository.GenerateStub<Model.Post>();
            var postComment = MockRepository.GenerateStub<PostComment>();

            postService.CommentAdded += delegate { throw new AssertionException("Shouldn't be called"); };
            postService.CommentAdding += x => x.Cancel = true;
            postService.PostAdding += x => x.Cancel = true;
            postService.PostAdded += delegate { throw new AssertionException("Shouldn't be called"); };
            postService.PostRemoved += delegate { throw new AssertionException("Shouldn't be called"); };
            postService.PostRemoving += x => x.Cancel = true;
            postService.AddComment(postComment);
            postRepository.AssertWasNotCalled(x => x.SaveComment(postComment));
            postService.AddPost(post);
            postRepository.AssertWasNotCalled(x => x.SavePost(post));
            postService.RemovePost(post);
            postRepository.AssertWasNotCalled(x => x.DeletePost(post));
        }

        [Test]
        public void Can_get_post_by_id()
        {
            postService.GetPostById(BlogContext.Current.Blog, 1);
            postRepository.AssertWasCalled(x => x.GetPostById(BlogContext.Current.Blog, 1));
        }

        [Test]
        public void Can_get_post_by_friendlyTitle()
        {
            postService.GetPostByFriendlyTitle(BlogContext.Current.Blog, "friendlyTitle");
            postRepository.AssertWasCalled(x => x.GetByTitle(BlogContext.Current.Blog, "friendlyTitle"));
        }

        [Test]
        public void Can_get_posts_by_blog()
        {
            postService.GetPostsByBlog(BlogContext.Current.Blog);
            postRepository.AssertWasCalled(x => x.GetByBlog(BlogContext.Current.Blog));
        }

        [Test]
        public void Can_get_posts_by_blog_paged()
        {
            postService.GetPostsByBlogPaged(BlogContext.Current.Blog, 0, 10);
            postRepository.AssertWasCalled(x => x.GetByBlog(BlogContext.Current.Blog, 0, 10));
        }

        [Test]
        public void Can_get_posts_by_tag()
        {
            postService.GetPostsByTagPaged(BlogContext.Current.Blog, "friendlyTagName", 0, 10);
            postRepository.AssertWasCalled(x => x.GetByTag(BlogContext.Current.Blog, "friendlyTagName", 0, 10));
        }
    }
}