using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace BlogSharp.Core.Impl.DataAccess
{
    public class BlogRepository : Db4oRepository<IBlog>, IBlogRepository
    {
        public BlogRepository(IObjectContainer container)
            : base(container)
        {

        }

        #region Implementation of IBlogRepository

        /// <summary>
        /// Get the Blog of the Founder Author
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public IBlog GeyByFounder(int authorId)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<IBlog> Get()
        {
            return container.Cast<IBlog>().AsQueryable();
        }

        public IQueryable<IBlog> Get(int skip, int take)
        {
            return container.Cast<IBlog>().Skip(skip).Take(take).AsQueryable();
        }

        #endregion
    }
}
