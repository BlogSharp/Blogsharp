using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface IAuthor:IIdentifiable<int>
	{
		IList<IPost> Posts { get; set; }
		IList<IBlog> Blogs { get; set; }
		string Username { get; set; }
		string Password { get; set; }
		string Email { get; set; }
	}
}
