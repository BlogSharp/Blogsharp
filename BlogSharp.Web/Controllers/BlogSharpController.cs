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
		public virtual Blog CurrentBlog
		{
			get { return BlogContext.Current.Blog; }

		}
	}
}
