using System;
using System.Collections.Generic;
using System.IO;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.DataAccess;
using BlogSharp.Model;
using BlogSharp.Model.Impl;
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

			var blog = GetEntityFactory<IBlog>().Create();
			blog.Id = 1;
        	var author = GetEntityFactory<IUser>().Create();
        	author.Id = 1;
        	var tag1 = GetEntityFactory<ITag>().Create();
        	tag1.Id = 1;
        	tag1.Name = "mytag";

			var tag2 = GetEntityFactory<ITag>().Create();
        	tag2.Id = 2;
        	tag2.Name = "mytag2";
        	var tags = new[] {tag1, tag2};
			for (int i = 0; i < 20; i++)
			{
				var post = GetEntityFactory<IPost>().Create();
				post.User = author;
				post.Blog = blog;
				post.Id = i;
				post.DatePublished = new DateTime(2009,11,11).AddMinutes(i);
				post.Title = string.Format("Test Post - {0}", i);
				post.Comments=new List<IPostComment>();
				post.Tags.Add(tags[i%tags.Length]);
				var comment1 = GetEntityFactory<IPostComment>().Create();
				var comment2 = GetEntityFactory<IPostComment>().Create();
				comment1.Comment = "naber";
				comment2.Comment = "iyidir";
				comment1.Post = post;
				comment2.Post = post;
				post.Comments.Add(comment1);
				post.Comments.Add(comment2);
				objectContainer.Store(comment1);
				objectContainer.Store(comment2);
				objectContainer.Store(post);
			}
			objectContainer.Store(author);
			objectContainer.Store(blog);
			objectContainer.Store(tag1);
			objectContainer.Store(tag2);
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
        public void Can_delete_a_post()
        {
        	var post = postRepository.GetPostById(9);
            postRepository.DeletePost(post);
			var foundPost = postRepository.GetPostById(9);
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
        public void Can_delete_a_comment()
        {

        	var post = postRepository.GetPostById(1);
        	var comment = post.Comments[0];
			postRepository.DeleteComment(comment);
			post = postRepository.GetPostById(1);
			Assert.Equal(1, post.Comments.Count);
        }

        [Fact]
        public void Can_get_by_post_id()
        {

            var foundPost = postRepository.GetPostById(2);
            Assert.NotNull(foundPost);
            Assert.Equal(2, foundPost.Id);
			Assert.Equal("Test Post - 2", foundPost.Title);
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
            var foundPosts = postRepository.GetByBlog(1);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(20, foundPosts.Count);
            Assert.Equal(19, foundPosts[0].Id);
            Assert.Equal("Test Post - 19", foundPosts[0].Title);
        }

        [Fact]
        public void Can_get_by_blog_paging()
        {
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
            var foundPosts = postRepository.GetByTag(1, 1, 0, 10);
            Assert.Equal(10, foundPosts.Count);

            foundPosts = postRepository.GetByTag(1, 1, 1, 10);
            Assert.NotEmpty(foundPosts);
            Assert.Equal(9, foundPosts.Count);

            foundPosts = postRepository.GetByTag(1, 1, 15, 10);
            Assert.Empty(foundPosts);
        }

		[Fact]
		public void Can_get_by_date()
		{
			var foundPosts = postRepository.GetByDate(1, new DateTime(2009,11,11), 0, 5);
			Assert.Equal(5,foundPosts.Count);
		}
    }
}
