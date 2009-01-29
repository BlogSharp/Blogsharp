using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public class Tag : IEntity
	{
		public Tag()
		{
			this.Posts=new List<Post>();
		}

		#region ITag Members

		public string Name
		{
			get;
			set;
		}

		public Blog Blog
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


		public IList<Post> Posts
		{
			get; 
			set;
		}

		#endregion
	}
}
