using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public class User : IEntity
	{
		public User()
		{
			this.Posts=new List<Post>();
			this.Blogs=new List<Blog>();
		}


		#region User Members

		public IList<Post> Posts
		{
			get;
			set;
		}

		public IList<Blog> Blogs
		{
			get;
			set;
		}

		public string Username
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		#endregion

		#region IIdentifiable<int> Members

		public int Id
		{
			get;
			set;
		}

		#endregion
	}
}
