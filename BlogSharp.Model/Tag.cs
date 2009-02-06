using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSharp.Model
{
	[Serializable]
	public class Tag : IEntity
	{
		public Tag()
		{
			Posts = new List<Post>();
		}

		[Required]
		public string Name { get; set; }

		[Required]
	    public string FriendlyName { get; set; }

		[Required]
		public Blog Blog { get; set; }

		public int Id { get; set; }

		public IList<Post> Posts { get; set; }
	}
}