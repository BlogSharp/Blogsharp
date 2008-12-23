using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace BlogSharp.Core.Impl.DataAccess
{
    public class BlogRepository : Db4oRepository, IBlogRepository
    {
        public BlogRepository(IObjectContainer container)
			:base(container)
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
        	return container.Query<IBlog>(x => x.Founder.Id == authorId).FirstOrDefault();
        }

        public IQueryable<IBlog> GetAllBlogs()
        {
            return container.Cast<IBlog>().AsQueryable();
        }

		public void SaveBlog(IBlog blog)
		{
			this.container.Store(blog);
		}

		public void DeleteBlog(IBlog blog)
		{
			this.container.Delete(blog);
		}


		#endregion
	}
}
