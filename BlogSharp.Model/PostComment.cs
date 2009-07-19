namespace BlogSharp.Model
{
	using System;
	using Interfaces;

	/// <summary>
	/// Represents a Comment to an entry.
	/// </summary>
	[Serializable]
	public class PostComment : CommentableEntity
	{
		/// <summary>
		/// Gets or sets Post.
		/// </summary>
		public virtual ICommentable Post { get; set; }

		/// <summary>
		/// Gets or sets Comment.
		/// </summary>
		public virtual string Comment { get; set; }

		/// <summary>
		/// Gets or sets the commenter. 
		/// This is a registered user comment (such as the blog owner).
		/// </summary>
		public virtual User Commenter { get; set; }

		/// <summary>
		/// Gets or sets Email.
		/// </summary>
		public virtual string Email { get; set; }

		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets Web.
		/// </summary>
		public virtual string Web { get; set; }

		/// <summary>
		/// Gets or sets Date.
		/// </summary>
		public virtual DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether Published.
		/// </summary>
		public virtual bool Published { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether Spam.
		/// </summary>
		public virtual bool Spam { get; set; }
	}
}