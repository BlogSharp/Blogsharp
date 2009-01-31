using System;
using System.Web;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Web
{
	public class BlogContext
	{
		public const string BLOG_CONTEXTKEY = "blogcontext";

		
		public static BlogContext Current
		{
			get { return current; }
			set { current = value; }
		}

		[ThreadStatic]
		private static BlogContext current;

		public Blog Blog { get; set; }
	}
}