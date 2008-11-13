using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface IBlog:IIdentifiable<int>
	{
		string Name { get; set; }
		IAuthor Founder { get; set; }
		IList<IAuthor> Authors { get; set; }
		IList<IPost> Posts { get; set; }
	}
}
