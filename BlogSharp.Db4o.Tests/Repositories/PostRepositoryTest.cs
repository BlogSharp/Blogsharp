using System;
using System.Collections.Generic;
using System.IO;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Db4o.Repositories;
using BlogSharp.Model;
using Db4objects.Db4o;
using Xunit;

namespace BlogSharp.Db4o.Tests.Repositories
{
	public class PostRepositoryTest : BaseTest
	{
		private readonly IPostRepository postRepository;

		public PostRepositoryTest()
		{

			postRepository = new PostRepository(this.objectContainerManager);

			var blog = new Blog();
			blog.Id = 1;
			var author = new BlogSharp.Model.User {Id = 1};
			var tag1 = new Tag {Id = 1, Name = "mytag"};

			var tag2 = new Tag {Id = 2, Name = "mytag2"};
			var tags = new[] { tag1, tag2 };
			objectContainer.Store(author);
			objectContainer.Store(blog);
			objectContainer.Store(tag1);
			objectContainer.Store(tag2);
			for (int i = 0; i < 20; i++)
			{
				var post = new Post();
				post.User = author;
				post.Blog = blog;
				post.Id = i;
				post.DatePublished = new DateTime(2009, 11, 11).AddMinutes(i);
				post.Title = string.Format("Test Post - {0}", i);
				post.Comments = new List<PostComment>();
				post.Tags.Add(tags[i % tags.Length]);
				tags[i%tags.Length].Posts.Add(post);
				var comment1 = new PostComment();
				var comment2 = new PostComment();
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

			objectContainer.Commit();
		}

		[Fact]
		public void Can_store_an_post()
		{
			var post = new Post();
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
			var post = new Post();
			var comment = new PostComment();
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
			var post = new Post();
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

			foundPosts = postRepository.GetByTag(1, 2, 1, 10);
			Assert.Equal(9, foundPosts.Count);

			foundPosts = postRepository.GetByTag(1, 1, 15, 10);
			Assert.Empty(foundPosts);
		}

		[Fact]
		public void Can_get_by_date()
		{
			var foundPosts = postRepository.GetByDate(1, new DateTime(2009, 11, 11), 0, 5);
			Assert.Equal(5, foundPosts.Count);
		}
	}
}