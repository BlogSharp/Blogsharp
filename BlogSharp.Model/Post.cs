// <copyright file="Post.cs" company="BlogSharp">
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
    /// Represents a Post into the Blog.
    /// </summary>
    public class Post : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Post" /> class. 
        /// </summary>
        public Post()
        {
            this.Comments = new List<PostComment>();
            this.Tags = new List<Tag>();
        }

        /// <summary>
        /// Gets or sets Blog.
        /// </summary>
        public Blog Blog { get; set; }

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets DateCreated.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets DatePublished.
        /// </summary>
        public DateTime DatePublished { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets FriendlyTitle.
        /// </summary>
        public string FriendlyTitle { get; set; }

        /// <summary>
        /// Gets or sets Content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        public IList<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets Comments.
        /// </summary>
        public IList<PostComment> Comments { get; set; }

        /// <summary>
        /// Adds a Comment to a Post.
        /// </summary>
        /// <param name="comment">The Comment to add.</param>
        public void AddComment(PostComment comment)
        {
            this.Comments.Add(comment);
            comment.Post = this;
        }
    }
}
