namespace BlogSharp.Db4o.Tests.Repositories
{
	using System;
	using System.Collections.Generic;
	using Blog.Repositories;
	using Core.Persistence.Repositories;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class PostRepositoryTest : BaseTest
	{
		#region Setup/Teardown

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.postRepository = new PostRepository(this.objectContainerManager);

			this.blog = new BlogSharp.Model.Blog {ID = 1};
			var author = new User {ID = 1};
			var tag1 = new Tag {ID = 1, Name = "mytag", FriendlyName = "mytag", Blog = this.blog};

			var tag2 = new Tag {ID = 2, Name = "mytag2", FriendlyName = "mytag2"};
			var tags = new[] {tag1, tag2};
			this.objectContainer.Store(author);
			this.objectContainer.Store(this.blog);

			for (int i = 0; i < 20; i++)
			{
				var post = new Post();
				post.User = author;
				post.Blog = this.blog;
				post.ID = i;
				post.DatePublished = new DateTime(2009, 11, 11).AddMinutes(i);
				post.Title = string.Format("Test Post - {0}", i);
				post.Comments = new List<PostComment>();
				post.Tags.Add(tags[i%tags.Length]);
				tags[i%tags.Length].Posts.Add(post);
				var comment1 = new PostComment();
				var comment2 = new PostComment();
				comment1.Comment = "naber";
				comment2.Comment = "iyidir";
				comment1.Post = post;
				comment2.Post = post;
				post.Comments.Add(comment1);
				post.Comments.Add(comment2);
				this.objectContainer.Store(comment1);
				this.objectContainer.Store(comment2);
				this.objectContainer.Store(post);
				this.objectContainer.Store(post.Comments);
				this.objectContainer.Store(post.Tags);
			}
			this.objectContainer.Store(tag1.Posts);
			this.objectContainer.Store(tag1.Posts);
			this.objectContainer.Commit();
		}

		#endregion

		private BlogSharp.Model.Blog blog;
		private IPostRepository postRepository;

		[Test]
		public void Can_delete_a_comment()
		{
			var post = this.postRepository.GetPostById(this.blog, 1);
			var comment = post.Comments[0];
			this.postRepository.DeleteComment(comment);
			post = this.postRepository.GetPostById(this.blog, 1);
			Assert.AreEqual(1, post.Comments.Count);
		}

		[Test]
		public void Can_delete_a_post()
		{
			var post = this.postRepository.GetPostById(this.blog, 9);
			this.postRepository.DeletePost(post);
			var foundPost = this.postRepository.GetPostById(this.blog, 9);
			Assert.Null(foundPost);
		}

		[Test]
		public void Can_get_by_author()
		{
			var foundPosts = this.postRepository.GetByAuthor(this.blog, 1, 0, 10);
			Assert.AreNotEqual(0, foundPosts.Count);
			Assert.AreEqual(10, foundPosts.Count);

			foundPosts = this.postRepository.GetByAuthor(this.blog, 1, 10, 10);
			Assert.AreNotEqual(0, foundPosts.Count);
			Assert.AreEqual(10, foundPosts.Count);

			foundPosts = this.postRepository.GetByAuthor(this.blog, 1, 15, 10);
			Assert.AreNotEqual(0, foundPosts.Count);
			Assert.AreEqual(5, foundPosts.Count);
		}

		[Test]
		public void Can_get_by_blog()
		{
			var foundPosts = this.postRepository.GetByBlog(this.blog);
			Assert.AreNotEqual(0, foundPosts.Count);
			Assert.AreEqual(20, foundPosts.Count);
			Assert.AreEqual(19, foundPosts[0].ID);
			Assert.AreEqual("Test Post - 19", foundPosts[0].Title);
		}

		[Test]
		public void Can_get_by_blog_paging()
		{
			var foundPosts = this.postRepository.GetByBlog(this.blog, 0, 10);
			Assert.AreNotEqual(0, foundPosts);
			Assert.AreEqual(10, foundPosts.Count);

			foundPosts = this.postRepository.GetByBlog(this.blog, 10, 10);
			Assert.AreNotEqual(0, foundPosts.Count);
			Assert.AreEqual(10, foundPosts.Count);

			foundPosts = this.postRepository.GetByBlog(this.blog, 15, 10);
			Assert.AreNotEqual(0, foundPosts.Count);
			Assert.AreEqual(5, foundPosts.Count);
		}

		[Test]
		public void Can_get_by_date()
		{
			var foundPosts = this.postRepository.GetByDate(this.blog, new DateTime(2009, 11, 11), 0, 5);
			Assert.AreEqual(5, foundPosts.Count);
		}

		[Test]
		public void Can_get_by_post_id()
		{
			var foundPost = this.postRepository.GetPostById(this.blog, 2);
			Assert.NotNull(foundPost);
			Assert.AreEqual(2, foundPost.ID);
			Assert.AreEqual("Test Post - 2", foundPost.Title);
		}

		[Test]
		public void Can_get_by_post_title()
		{
			var post = new Post();
			post.ID = 1;
			post.Title = "Test Post";
			post.FriendlyTitle = "test-post";
			this.postRepository.SavePost(post);

			var foundPost = this.postRepository.GetByTitle(this.blog, "test-post");
			Assert.NotNull(foundPost);
			Assert.AreEqual(1, foundPost.ID);
			Assert.AreEqual("Test Post", foundPost.Title);
		}

		[Test]
		public void Can_get_by_tag()
		{
			var foundPosts = this.postRepository.GetByTag(this.blog, "mytag", 0, 10);
			Assert.AreEqual(10, foundPosts.Count);

			foundPosts = this.postRepository.GetByTag(this.blog, "mytag", 1, 10);
			Assert.AreEqual(9, foundPosts.Count);

			foundPosts = this.postRepository.GetByTag(this.blog, "mytag", 15, 10);
			Assert.AreEqual(0, foundPosts.Count);
		}

		[Test]
		public void Can_store_an_comment()
		{
			var post = new Post();
			var comment = new PostComment();
			comment.Post = post;
			this.postRepository.SaveComment(comment);
		}

		[Test]
		public void Can_store_an_post()
		{
			var post = new Post();
			this.postRepository.SavePost(post);
		}
	}
}