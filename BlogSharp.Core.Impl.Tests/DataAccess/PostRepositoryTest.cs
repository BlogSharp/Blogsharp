using System.Collections.Generic;
using System.IO;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.DataAccess
{
    public class PostRepositoryTest : BaseTest
    {
        private readonly IObjectContainer objectContainer;
        private readonly IPostRepository postRepository;

        public PostRepositoryTest()
        {
            objectContainer = Db4oFactory.OpenFile("test.db4o");
            postRepository = new PostRepository(objectContainer);
        }

        public override void OnTearDown()
        {
            objectContainer.Close();
            File.Delete(MapPath("test.db4o"));
        }

        [Fact]
        public void Can_store_an_post()
        {
            var post = GetEntityFactory<IPost>().Create();
            postRepository.SavePost(post);
        }

        [Fact]
        public void Can_delete_an_post()
        {
            var post = GetEntityFactory<IPost>().Create();
            post.Id = 1;
            postRepository.SavePost(post);
            postRepository.DeletePost(post);
            var foundPost = postRepository.GetPostById(1);
            Assert.Null(foundPost);
        }

        [Fact]
        public void Can_store_an_comment()
        {
            var post = GetEntityFactory<IPost>().Create();
            var comment = GetEntityFactory<IPostComment>().Create();
            comment.Post = post;
            postRepository.SaveComment(comment);
        }

        [Fact]
        public void Can_delete_an_comment()
        {
            var post = GetEntityFactory<IPost>().Create();
            var comment = GetEntityFactory<IPostComment>().Create();
            post.Id = 1;
            comment.Id = 1;
            comment.Post = post;
            postRepository.SaveComment(comment);
            postRepository.DeleteComment(comment);
            var foundPost = postRepository.GetPostById(1);
            Assert.Null(foundPost.Comments);
        }

        [Fact]
        public void Can_get_by_post_id()
        {
            var post = GetEntityFactory<IPost>().Create();
            post.Id = 1;
            post.Title = "Test Post";
            postRepository.SavePost(post);

            var foundPost = postRepository.GetPostById(1);
            Assert.NotNull(foundPost);
            Assert.Equal(1, foundPost.Id);
            Assert.Equal("Test Post", foundPost.Title);
        }

        [Fact]
        public void Can_get_by_post_title()
        {
            var post = GetEntityFactory<IPost>().Create();
            post.Id = 1;
            post.Title = "Test Post";
            post.FriendlyTitle = "test-post";
            postRepository.SavePost(post);

            var foundPost = postRepository.GetByTitle("test-post");
            Assert.NotNull(foundPost);
            Assert.Equal(1, foundPost.Id);
            Assert.Equal("Test Post", foundPost.Title);
        }

        [Fact]
        public void Can_get_by_blog()
        {
            var blog = GetEntityFactory<IBlog>().Create();
            var post = GetEntityFactory<IPost>().Create();
            blog.Id = 1;
            post.Blog = blog;
            post.Id = 1;
            post.Title = "Test Post";
            postRepository.SavePost(post);

            var foundPosts = postRepository.GetByBlog(1);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(1, foundPosts.Count);
            Assert.Equal(1, foundPosts[0].Id);
            Assert.Equal("Test Post", foundPosts[0].Title);
        }

        [Fact]
        public void Can_get_by_blog_paging()
        {
            var blog = GetEntityFactory<IBlog>().Create();
            blog.Id = 1;

            // 20 posts are stored.
            for (int i = 0; i < 20; i++)
            {
                var post = GetEntityFactory<IPost>().Create();
                post.Blog = blog;
                post.Id = i;
                post.Title = string.Format("Test Post - {0}", i);
                postRepository.SavePost(post);
            }

            var foundPosts = postRepository.GetByBlog(1, 0, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByBlog(1, 10, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByBlog(1, 15, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(5, foundPosts.Count);
        }

        [Fact]
        public void Can_get_by_author()
        {
            var blog = GetEntityFactory<IBlog>().Create();
            blog.Id = 1;

            // 20 posts are stored.
            for (int i = 0; i < 20; i++)
            {
                var post = GetEntityFactory<IPost>().Create();
                var author = GetEntityFactory<IUser>().Create();
                author.Id = 1;
                author.Blogs = new List<IBlog> { blog };
                post.Blog = blog;
                post.User = author;
                post.Id = i;
                post.Title = string.Format("Test Post - {0}", i);
                postRepository.SavePost(post);
            }

            var foundPosts = postRepository.GetByAuthor(1, 1, 0, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByAuthor(1, 1, 10, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByAuthor(1, 1, 15, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(5, foundPosts.Count);
        }

        [Fact]
        public void Can_get_by_tag()
        {
            var blog = GetEntityFactory<IBlog>().Create();
            var tag = GetEntityFactory<ITag>().Create();
            tag.Id = 1;
            blog.Id = 1;

            // 20 posts are stored.
            for (int i = 0; i < 20; i++)
            {
                var post = GetEntityFactory<IPost>().Create();
                post.Blog = blog;
                post.Tags = new List<ITag> { tag };
                post.Id = i;
                post.Title = string.Format("Test Post - {0}", i);
                postRepository.SavePost(post);
            }

            var foundPosts = postRepository.GetByTag(1, 1, 0, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByTag(1, 1, 10, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByTag(1, 1, 15, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(5, foundPosts.Count);
        }

		[Fact]
		public void Can_get_by_date()
		{
			Assert.True(false); // not implemented test.
		}
    }
}
