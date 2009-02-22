namespace BlogSharp.Db4o.Blog.Repositories
{
	using System.Linq;
	using Core.Persistence.Repositories;

	public class UserRepository : Db4oRepository, IUserRepository
	{
		public UserRepository(IObjectContainerManager container)
			: base(container)
		{
		}

		#region Implementation of IUserRepository

		public Model.User GetAuthorByUsername(string username)
		{
			return this.container.GetContainer().Query<Model.User>(x => x.Username == username).SingleOrDefault();
		}

		public Model.User GetAuthorByEmail(string email)
		{
			return this.container.GetContainer().Query<Model.User>(x => x.Email == email).SingleOrDefault();
		}

		public void SaveUser(Model.User user)
		{
			this.SaveObject(user);
		}

		public void RemoveUser(Model.User user)
		{
			this.RemoveObject(user);
		}

		public Model.User GetById(int id)
		{
			return this.container.GetContainer().Query<Model.User>(x => x.ID == id).SingleOrDefault();
		}

		#endregion
	}
}