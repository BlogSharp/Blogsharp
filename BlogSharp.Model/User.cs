using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSharp.Model
{
	[Serializable]
	public class User : IEntity
	{
		public User()
		{
			Posts = new List<Post>();
			Blogs = new List<Blog>();
		}

		public IList<Post> Posts { get; set; }

		public IList<Blog> Blogs { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Email { get; set; }

		public int Id { get; set; }
	}
}