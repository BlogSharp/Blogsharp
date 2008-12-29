using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Impl
{
	public class Tag : ITag
	{

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

		public Guid Id
		{
			get;
			set;
		}

		#endregion

	}
}
