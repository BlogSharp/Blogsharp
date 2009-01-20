using System.Collections.Generic;
using System.Linq;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Model;
using Db4objects.Db4o;

namespace BlogSharp.Db4o.Repositories
{
    public class BlogRepository : Db4oRepository, IBlogRepository
    {
        public BlogRepository(IObjectContainerManager containerManager)
			: base(containerManager)
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
        	return container.GetContainer().Query<IBlog>(x => x.Founder.Id == authorId).FirstOrDefault();
        }

        public IList<IBlog> GetAllBlogs()
        {
			return container.GetContainer().Query<IBlog>();
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
