using System;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
	public interface IUserRepository
	{
		IUser GetAuthorByUsername(string username);
		IUser GetAuthorByEmail(string email);
		void SaveUser(IUser user);
		void RemoveUser(IUser user);
		IUser GetById(Guid id);
		
	}
}
