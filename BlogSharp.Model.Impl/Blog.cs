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
			this.Authors=new List<IAuthor>();
			this.Posts=new List<IPost>();
		}
		#region IBlog Members

		public string Name
		{
			get; set;
		}

		public IAuthor Founder
		{
			get; set;
		}

		public IList<IAuthor> Authors
		{
			get; set;
		}

		public IList<IPost> Posts
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
