// <copyright file="DefaultStartupInstaller.cs" company="BlogSharp">
// Coypyleft 2009 Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-06-20</date>

namespace BlogSharp.Core.Impl.Installers
{
    using System;
    using System.Collections.Generic;
    using Core.Structure;
    using Model;
    using Persistence.Repositories;

    /// <summary>
    /// Well... the name of the class says all.
    /// </summary>
    public class DefaultStartupInstaller : IStartupInstaller
    {
        private readonly IBlogRepository blogRepository;
        private readonly IFriendlyUrlGenerator generator;
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        private bool isInitialized;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultStartupInstaller" /> class. 
        /// </summary>
        /// <param name="blogRepository"></param>
        /// <param name="postRepository"></param>
        /// <param name="userRepository"></param>
        /// <param name="generator"></param>
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

        /// <summary>
        /// Executes the default install.
        /// </summary>
        public void Execute()
        {
            if (this.isInitialized)
            {
                return;
            }

            var blog = this.blogRepository.GetBlog();
            if (blog != null)
            {
                this.isInitialized = true;
                return;
            }

            var user = new User
                           {
                               UserName = "BlogSharp",
                               Password = "BlogSharp",
                               Email = "blogbharp@blogsharp.com",
                               ID = 1
                           };

            blog = new Blog
                       {
                           ID = 1,
                           Title = "BlogSharp Blogs",
                           Writers = new List<User> { user },
                           Founder = user,
                           Configuration = new BlogConfiguration { PageSize = 10 },
                           Host = "localhost",
                           Name = "BlogSharp",
                       };

            var tag = new Tag { ID = 1, Name = "Welcome", FriendlyName = "welcome" };
            var title = "Welcome to BlogSharp!";
            var post = new Post
                           {
                               ID = 1,
                               Blog = blog,
                               Publisher = user,
                               Tags = new List<Tag> { tag },
                               Title = title,
                               Content = "Great blog post is here you are.",
                               FriendlyTitle = this.generator.GenerateUrl("{0}", title),
                               DateCreated = DateTime.Now,
                               DatePublished = DateTime.Now
                           };
            tag.Posts.Add(post);
            blog.Configuration = new BlogConfiguration { PageSize = 10 };
            blog.Posts.Add(post);
            this.userRepository.SaveUser(user);
            this.blogRepository.SaveBlog(blog);
            this.postRepository.SavePost(post);
            this.isInitialized = true;
        }

        #endregion
    }
}