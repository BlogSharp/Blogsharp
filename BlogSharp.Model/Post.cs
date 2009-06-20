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
	using Interfaces;

	/// <summary>
	/// Represents a Post into the Blog.
	/// </summary>
	public class Post : Entity, IPostable, ITaggable, ICommentable
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
		/// Gets or sets Title.
		/// </summary>
		public virtual string Title { get; set; }

		/// <summary>
		/// Gets or sets FriendlyTitle.
		/// </summary>
		public virtual string FriendlyTitle { get; set; }

		#region Implementation of ICommentable
		/// <summary>
		/// Gets or sets Comments.
		/// </summary>
		public virtual IList<PostComment> Comments { get; set; }
    	#endregion
		#region Implementation of ITaggable
		/// <summary>
		/// Gets or sets Tags.
		/// </summary>
		public virtual IList<Tag> Tags { get; set; }
		#endregion
		#region Implementation of IPostable
		/// <summary>
		/// Gets or sets Blog.
		/// </summary>
		public virtual Blog Blog { get; set; }

		/// <summary>
		/// Gets or sets User.
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// Gets or sets DateCreated.
		/// </summary>
		public virtual DateTime DateCreated { get; set; }

		/// <summary>
		/// Gets or sets DatePublished.
		/// </summary>
		public virtual DateTime DatePublished { get; set; }

		/// <summary>
		/// Gets or sets Content.
		/// </summary>
		public virtual string Content { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
		public virtual string Email{ get; set; }
		#endregion
		#region Implementation of ICommentable
		/// <summary>
		/// Adds a Comment to a Post.
		/// </summary>
		/// <param name="comment">The Comment to add.</param>
		/// <param name="post">The Post to comment.</param>
		public virtual void AddComment(PostComment comment, ICommentable post)
		{
			if (post == null)
			{
				post = this;
			}

			post.Comments.Add(comment);
			comment.Post = post;
		}
		#endregion
        }
}