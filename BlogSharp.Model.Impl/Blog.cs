using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Impl
{
	public class Blog:IBlog
	{
		public Blog()
		{
			this.Authors=new List<IUser>();
			this.Posts=new List<IPost>();
		}
		#region IBlog Members

		public string Name
		{
			get; set;
		}

		public IUser Founder
		{
			get; set;
		}

		public IList<IUser> Authors
		{
			get; set;
		}

		public IList<IPost> Posts
		{
			get; set;
		}

		#endregion

		#region IIdentifiable<int> Members

		public Guid Id
		{
			get; set;
		}

		#endregion
	}
}
