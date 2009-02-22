// <copyright file="User.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent a User of the system.
    /// </summary>
    [Serializable]
    public class User : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class. 
        /// </summary>
        public User()
        {
            this.Posts = new List<Post>();
            this.Blogs = new List<Blog>();
        }

        /// <summary>
        /// Gets or sets Posts.
        /// </summary>
        public IList<Post> Posts { get; set; }

        /// <summary>
        /// Gets or sets Blogs.
        /// </summary>
        public IList<Blog> Blogs { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }
    }
}
