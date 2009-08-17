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
			// this.Posts = new List<Post>();
			Blogs = new List<Blog>();
		}

		///// <summary>
		///// Gets or sets Posts.
		///// </summary>
		// public virtual IList<Post> Posts { get; set; }

		/// <summary>
		/// Gets or sets Blogs.
		/// </summary>
		public virtual IList<Blog> Blogs { get; set; }

		/// <summary>
		/// Gets or sets UserName.
		/// </summary>
		public virtual string UserName { get; set; }

		/// <summary>
		/// Gets or sets Password.
		/// </summary>
		public virtual string Password { get; set; }

		/// <summary>
		/// Gets or sets Email.
		/// </summary>
		public virtual string Email { get; set; }

		/// <summary>
		/// Gets or sets Biography.
		/// </summary>
		public virtual string Biography { get; set; }

		/// <summary>
		/// Gets or sets BirthDate.
		/// </summary>
		public virtual DateTime? BirthDate { get; set; }
	}
}