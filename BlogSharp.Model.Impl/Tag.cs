using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Impl
{
	public class Tag : ITag
	{
		public Tag()
		{
			this.Posts=new List<IPost>();
		}

		#region ITag Members

		public string Name
		{
			get;
			set;
		}

		public IBlog Blog
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


		#region ITag Members


		public IList<IPost> Posts
		{
			get; 
			set;
		}

		#endregion
	}
}
