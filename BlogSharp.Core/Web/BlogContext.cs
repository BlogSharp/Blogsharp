using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BlogSharp.Model;

namespace BlogSharp.Core.Web
{
	public class BlogContext
	{
		public const string BLOG_CONTEXTKEY="blogcontext";
		public static BlogContext Current
		{
			get { return (BlogContext)HttpContext.Current.Items[BLOG_CONTEXTKEY]; }
			internal set { HttpContext.Current.Items[BLOG_CONTEXTKEY] = value; }
		}

		public Blog Blog { get; set; }

	}
}
