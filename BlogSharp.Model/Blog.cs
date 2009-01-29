using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public class Blog:IEntity
	{
		public Blog()
		{
			this.Authors=new List<User>();
			this.Posts=new List<Post>();
		}
		#region Blog Members

		public string Name
		{
			get; set;
		}

		public User Founder
		{
			get; set;
		}

		public IList<User> Authors
		{
			get; set;
		}

		public IList<Post> Posts
		{
			get; set;
		}
		public string Title
		{
			get; set;
		}

		public string Host
		{
			get; set;
		}

		public bool IsInitialized
		{
			get; set;
		}
		#endregion

		#region IIdentifiable<int> Members

		public int Id
		{
			get; set;
		}

		#endregion


	}
}
