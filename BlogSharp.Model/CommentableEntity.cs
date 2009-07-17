// <copyright file="CommentableEntity.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-06-23</date>

namespace BlogSharp.Model
{
	using System;
	using System.Collections.Generic;
	using Interfaces;

	/// <summary>
	/// This class represents every entity that can be commentable.
	/// </summary>
	[Serializable]
	public abstract class CommentableEntity : Entity, ICommentable
	{
		#region Implementation of ICommentable

		///// <summary>
		///// Gets or sets Blog.
		///// </summary>
		// public Blog Blog { get; set; }

		/// <summary>
		/// Gets or sets Comments.
		/// </summary>
		public virtual IList<ICommentable> Comments { get; set; }

		/// <summary>
		/// Adds a Comment to a Post.
		/// </summary>
		/// <param name="comment">The Comment to add.</param>
		/// <param name="commented">The commented entity.</param>
		public virtual void AddComment(ICommentable comment, ICommentable commented)
		{
			// Initialize the collection if needed
			if (Comments == null)
			{
				Comments = new List<ICommentable>();
			}

			// See if the commented entity is this
			if (commented == null)
			{
				commented = this;
			}

			commented.Comments.Add(comment);
		}

		#endregion
	}
}