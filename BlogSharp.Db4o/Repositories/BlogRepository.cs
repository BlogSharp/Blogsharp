using System.Linq;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Model;

namespace BlogSharp.Db4o.Repositories
{
	public class BlogRepository : Db4oRepository, IBlogRepository
	{
		public BlogRepository(IObjectContainerManager containerManager)
			: base(containerManager)
		{
		}

		#region Implementation of IBlogRepository

		public void SaveBlog(Blog blog)
		{
			SaveObject(blog);
			container.GetContainer().Commit();
		}

		public void DeleteBlog(Blog blog)
		{
			RemoveObject(blog);
		}

		#endregion

		#region IBlogRepository Members

		public Blog GetBlog()
		{
			return container.GetContainer()
				.Query<Model.Blog>()
				.SingleOrDefault();
		}

		#endregion
	}
}