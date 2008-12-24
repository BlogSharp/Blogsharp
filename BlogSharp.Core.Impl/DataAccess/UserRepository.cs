using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;

namespace BlogSharp.Core.Impl.DataAccess
{
    public class UserRepository : Db4oRepository, IUserRepository
    {
        public UserRepository(IObjectContainer container)
            : base(container)
        {

        }

        #region Implementation of IUserRepository

        public IUser GetAuthorByUsername(string username)
        {
            return container.Query<IUser>(x => x.Username == username).SingleOrDefault();
        }

        public IUser GetAuthorByEmail(string email)
        {
            return container.Query<IUser>(x => x.Email == email).SingleOrDefault();
        }

        public void SaveUser(IUser user)
        {
            SaveObject(user);
        }

        public void RemoveUser(IUser user)
        {
            RemoveObject(user);
        }

        #endregion
    }
}
