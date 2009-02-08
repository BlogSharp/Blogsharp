using System.Linq;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Model;
namespace BlogSharp.Db4o.Blog.Repositories
{
	public class BlogRepository : Db4oRepository, IBlogRepository
	{
		public BlogRepository(IObjectContainerManager containerManager)
			: base(containerManager)
		{
		}

		#region Implementation of IBlogRepository

		public void SaveBlog(BlogSharp.Model.Blog blog)
		{
			SaveObject(blog);
		}

		public void DeleteBlog(BlogSharp.Model.Blog blog)
		{
			RemoveObject(blog);
		}

		#endregion

		#region IBlogRepository Members

		public BlogSharp.Model.Blog GetBlog()
		{
			return container.GetContainer()
				.Query<Model.Blog>()
				.SingleOrDefault();
		}

		#endregion
	}
}