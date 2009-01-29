using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public class PostComment : IEntity
	{
		#region PostComment Members

		public Post Post
		{
			get;
			set;
		}

		public string Comment
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
