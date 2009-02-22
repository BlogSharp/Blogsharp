namespace BlogSharp.Core.Persistence.Repositories
{
	using Model;

	public interface IUserRepository
	{
		User GetAuthorByUsername(string username);
		User GetAuthorByEmail(string email);
		void SaveUser(User user);
		void RemoveUser(User user);
		User GetById(int id);
	}
}