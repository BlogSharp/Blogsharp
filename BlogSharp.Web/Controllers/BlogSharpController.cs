using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSharp.Core.Impl.Web;
using BlogSharp.Model;

namespace BlogSharp.Web.Controllers
{
	public abstract class BlogSharpController:Controller
	{
		protected virtual Blog CurrentBlog
		{
			get { return CurrentBlogContext.Blog; }
		}
		protected virtual BlogContext CurrentBlogContext
		{
			get { return BlogContextProvider.Current.GetCurrentBlogContext(); }
		}

	}
}
