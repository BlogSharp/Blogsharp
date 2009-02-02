using System;
using System.Collections.Generic;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Structure;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Installers
{
	public class DefaultStartupInstaller : IStartupInstaller
	{
		private readonly IBlogRepository blogRepository;
		private readonly IFriendlyUrlGenerator generator;
		private readonly IPostRepository postRepository;
		private readonly IUserRepository userRepository;

		public DefaultStartupInstaller(IBlogRepository blogRepository,
		                               IPostRepository postRepository,
		                               IUserRepository userRepository,
		                               IFriendlyUrlGenerator generator)
		{
			this.blogRepository = blogRepository;
			this.postRepository = postRepository;
			this.userRepository = userRepository;
			this.generator = generator;
		}

		#region IStartupInstaller Members

		public void Execute()
		{
			var blog = blogRepository.GetBlog();
			if (blog != null) return;

			var user = new User
			           	{
			           		Username = "blogsharp",
			           		Password = "blogsharp",
			           		Email = "blogsh@rp.com",
			           		Id = 1
			           	};

			blog = new Blog
			       	{
			       		Id = 1,
			       		Title = "BlogSharp Blogs",
			       		Authors = new List<User> {user},
			       		Founder = user
			       	};

			var tag = new Tag {Id = 1, Name = "Welcome"};
			string title = "Welcome to Blogsharp!";
			var post = new Post
			           	{
			           		Id = 1,
			           		Blog = blog,
			           		User = user,
			           		Tags = new List<Tag> {tag},
			           		Title = title,
			           		Content = "Great blog post is here you are.",
			           		FriendlyTitle = generator.GenerateUrl("{0}", title),
			           		DateCreated = DateTime.Now,
			           		DatePublished = DateTime.Now
			           	};
			tag.Posts.Add(post);
			blog.Configuration = new BlogConfiguration {PageSize = 10};
			blog.Posts.Add(post);
			userRepository.SaveUser(user);
			blogRepository.SaveBlog(blog);
			postRepository.SavePost(post);
		}

		#endregion
	}
}