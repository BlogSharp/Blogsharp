using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSharp.Model
{
	[Serializable]
	public class Blog : IEntity
	{
		public Blog()
		{
			Authors = new List<User>();
			Posts = new List<Post>();
		}

		public BlogConfiguration Configuration { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public User Founder { get; set; }

		public IList<User> Authors { get; set; }

		public IList<Post> Posts { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Host { get; set; }

		public bool IsInitialized { get; set; }

		public int Id { get; set; }
	}
}