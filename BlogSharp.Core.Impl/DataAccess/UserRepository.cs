using System;
using System.Linq;
using BlogSharp.CastleExtensions.Facilities.Db4o;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;

namespace BlogSharp.Core.Impl.DataAccess
{
    public class UserRepository : Db4oRepository, IUserRepository
    {
        public UserRepository(ISessionManager session)
            : base(session)
        {
        	container = session.OpenFile();
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

    	public IUser GetById(Guid id)
    	{
    		return container.Query<IUser>(x => x.Id == id).SingleOrDefault();
    	}

    	#endregion
    }
}
