using System;
using System.Collections.Generic;

namespace BlogSharp.Model
{
	[Serializable]
	public class Tag : IEntity
	{
		public Tag()
		{
			Posts = new List<Post>();
		}

		public string Name { get; set; }

	    public string FriendlyName { get; set; }

		public Blog Blog { get; set; }

		public int Id { get; set; }

		public IList<Post> Posts { get; set; }
	}
}
