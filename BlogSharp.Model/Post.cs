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
	[Serializable]
	public class Post : CommentableEntity, IPostable, ITaggable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Post" /> class. 
		/// </summary>
		public Post()
		{
			Tags = new List<Tag>();
		}

		/// <summary>
		/// Gets or sets Title.
		/// </summary>
		public virtual string Title { get; set; }

		/// <summary>
		/// Gets or sets FriendlyTitle.
		/// </summary>
		public virtual string FriendlyTitle { get; set; }

		#region Implementation of ITaggable

		/// <summary>
		/// Gets or sets Tags.
		/// </summary>
		public virtual IList<Tag> Tags { get; set; }

		#endregion

		#region Implementation of IPostable

		/// <summary>
		/// Gets or sets a value indicating whether Published.
		/// </summary>
		public virtual bool Published { get; set; }

		/// <summary>
		/// Gets or sets Blog.
		/// </summary>
		public virtual Blog Blog { get; set; }

		/// <summary>
		/// Gets or sets User.
		/// </summary>
		public virtual User Publisher { get; set; }

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

		#endregion
	}
}