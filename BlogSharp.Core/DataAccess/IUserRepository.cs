using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
	public interface IUserRepository
	{
		IAuthor GetAuthorByUsername(string username);

	}
}
