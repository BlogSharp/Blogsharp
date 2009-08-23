namespace BlogSharp.Model
{
	using System;
	using System.Collections.Generic;
	using Interfaces;

	/// <summary>
	/// Represents a Feedback to an entry.
	/// </summary>
	[Serializable]
	public class Comment : Feedback
	{
		/// <summary>
		/// Gets or sets Email.
		/// </summary>
		public virtual string Email { get; set; }

		/// <summary>
		/// Gets or sets the commenter. 
		/// This is a registered user comment (such as the blog owner).
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// Gets or sets Web.
		/// </summary>
		public virtual string Web { get; set; }

	}
}