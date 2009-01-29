using BlogSharp.Model;

namespace BlogSharp.Core.Persistence.Repositories
{
	public interface IUserRepository
	{
		User GetAuthorByUsername(string username);
		User GetAuthorByEmail(string email);
		void SaveUser(User user);
		void RemoveUser(User user);
		User GetById(int id);
		
	}
}