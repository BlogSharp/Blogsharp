using System.Collections.Generic;
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
        /// Get the Blog of the Founder User
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public IBlog GeyByFounder(int authorId)
        {
        	return container.Query<IBlog>(x => x.Founder.Id == authorId).FirstOrDefault();
        }

        public IList<IBlog> GetAllBlogs()
        {
            return container.Cast<IBlog>().ToList();
        }

		public void SaveBlog(IBlog blog)
		{
			SaveObject(blog);
		}

		public void DeleteBlog(IBlog blog)
		{
			RemoveObject(blog);
		}

		#endregion
	}
}
