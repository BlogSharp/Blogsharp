using System.Linq;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Model;
using Db4objects.Db4o;

namespace BlogSharp.Db4o.Repositories
{
    public class UserRepository : Db4oRepository, IUserRepository
    {
        public UserRepository(IObjectContainerManager container)
            : base(container)
        {

        }

        #region Implementation of IUserRepository

        public IUser GetAuthorByUsername(string username)
        {
            return container.GetContainer().Query<IUser>(x => x.Username == username).SingleOrDefault();
        }

        public IUser GetAuthorByEmail(string email)
        {
			return container.GetContainer().Query<IUser>(x => x.Email == email).SingleOrDefault();
        }

        public void SaveUser(IUser user)
        {
            SaveObject(user);
        }

        public void RemoveUser(IUser user)
        {
            RemoveObject(user);
        }

    	public IUser GetById(int id)
    	{
			return container.GetContainer().Query<IUser>(x => x.Id == id).SingleOrDefault();
    	}

    	#endregion
    }
}
