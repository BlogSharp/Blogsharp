using System.Collections.Generic;

namespace BlogSharp.Model
{
	public class User : IEntity
	{
		public User()
		{
			Posts = new List<Post>();
			Blogs = new List<Blog>();
		}

		public IList<Post> Posts { get; set; }

		public IList<Blog> Blogs { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public int Id { get; set; }
	}
}