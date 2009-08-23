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
			this.blogs = new List<Blog>();
		}

		private IList<Blog> blogs;
		///// <summary>
		///// Gets or sets Posts.
		///// </summary>
		// public virtual IList<Post> Posts { get; set; }

		/// <summary>
		/// Gets or sets Blogs.
		/// </summary>
		public virtual IEnumerable<Blog> Blogs
		{
			get{ return blogs;}
		}

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

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (User)) return false;
			return Equals((User) obj);
		}

		public virtual bool Equals(User other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.UserName, UserName) && Equals(other.Password, Password) && Equals(other.Email, Email) && Equals(other.Biography, Biography) && other.BirthDate.Equals(BirthDate);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = (UserName != null ? UserName.GetHashCode() : 0);
				result = (result*397) ^ (Password != null ? Password.GetHashCode() : 0);
				result = (result*397) ^ (Email != null ? Email.GetHashCode() : 0);
				result = (result*397) ^ (Biography != null ? Biography.GetHashCode() : 0);
				result = (result*397) ^ (BirthDate.HasValue ? BirthDate.Value.GetHashCode() : 0);
				return result;
			}
		}
	}
}