using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Impl
{
	public class PostComment : IPostComment
	{
		#region IPostComment Members

		public IPost Post
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

		public Guid Id
		{
			get;
			set;
		}

		#endregion
	}
}
