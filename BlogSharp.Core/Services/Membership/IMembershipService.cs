using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.Services.Membership
{
	public interface IMembershipService
	{
		IAuthor CreateNewUser(string username, string password, string email);
		void DeleteUser(string username);
		void DeleteUser(IAuthor author);
		IAuthor GetAuthorInfoByName(string author);
		void ResetPassword(string email);
	}
}
