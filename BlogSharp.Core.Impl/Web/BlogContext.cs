using System;
using System.Web;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Web
{
	public class BlogContext
	{
		public virtual Blog Blog { get; set; }
	}
}
