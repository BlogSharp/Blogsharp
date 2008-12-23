using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IBlogRepository : IRepository<IBlog>
    {
        /// <summary>
        /// Get the Blog of the Founder Author
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        IBlog GeyByFounder(int authorId);
        IQueryable<IBlog> Get();
        IQueryable<IBlog> Get(int skip, int take);
    }
}
