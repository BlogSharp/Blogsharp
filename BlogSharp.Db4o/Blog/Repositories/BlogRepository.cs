namespace BlogSharp.Db4o.Blog.Repositories
{
	using System.Linq;
	using Core.Persistence.Repositories;

	public class BlogRepository : Db4oRepository, IBlogRepository
	{
		public BlogRepository(IObjectContainerManager containerManager)
			: base(containerManager)
		{
		}

		#region Implementation of IBlogRepository

		public void SaveBlog(BlogSharp.Model.Blog blog)
		{
			this.SaveObject(blog);
		}

		public void DeleteBlog(BlogSharp.Model.Blog blog)
		{
			this.RemoveObject(blog);
		}

		#endregion

		#region IBlogRepository Members

		public BlogSharp.Model.Blog GetBlog()
		{
			return this.container.GetContainer()
				.Query<Model.Blog>()
				.SingleOrDefault();
		}

		#endregion
	}
}