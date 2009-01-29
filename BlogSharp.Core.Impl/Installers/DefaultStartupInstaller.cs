using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Installers
{
	public class DefaultStartupInstaller : IStartupInstaller
	{
		private readonly IBlogRepository blogRepository;
		private readonly IPostRepository postRepository;
		private readonly IUserRepository userRepository;

		public DefaultStartupInstaller(IBlogRepository blogRepository,
										IPostRepository postRepository,
										IUserRepository userRepository)
		{
			this.blogRepository = blogRepository;
			this.postRepository = postRepository;
			this.userRepository = userRepository;
		}

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

			var post = new Post
			           	{
			           		Id = 1,
			           		Blog = blog,
			           		User = user,
			           		Tags = new List<Tag> {tag},
			           		Title = "Welcome to Blogsharp!",
			           		Content = "Great blog post is here you are.",
			           		DateCreated = DateTime.Now,
			           		DatePublished = DateTime.Now
			           	};

			userRepository.SaveUser(user);
			blogRepository.SaveBlog(blog);
			postRepository.SavePost(post);
		}
	}
}