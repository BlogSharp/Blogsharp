using System;
using System.Collections.Generic;
using System.Linq;
using BlogSharp.CastleExtensions.Facilities.Db4o;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace BlogSharp.Core.Impl.DataAccess
{
    public class BlogRepository : Db4oRepository, IBlogRepository
    {
		public BlogRepository(ISessionManager session)
			: base(session)
        {
			
        }

        #region Implementation of IBlogRepository

        /// <summary>
        /// Get the Blog of the Founder User
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public IBlog GeyByFounder(Guid authorId)
        {
			using (container = session.OpenFile())
			{
				return container.Query<IBlog>(x => x.Founder.Id == authorId).FirstOrDefault();
			}
        }

        public IList<IBlog> GetAllBlogs()
        {
			using (container = session.OpenFile())
			{
				return container.Cast<IBlog>().ToList();
			}
        }

		public void SaveBlog(IBlog blog)
		{
			using (container = session.OpenFile())
			{
				SaveObject(blog);
			}
		}

		public void DeleteBlog(IBlog blog)
		{
			using (container = session.OpenFile())
			{
				RemoveObject(blog);
			}
		}

		#endregion
	}
}
