using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Db4o.Repositories;
using BlogSharp.Model;
using Xunit;

namespace BlogSharp.Db4o.Tests.Repositories
{
	public class BlogRepositoryTests : BaseTest
	{
		private readonly IBlogRepository blogRepository;

		public BlogRepositoryTests()
		{
			blogRepository = new BlogRepository(objectContainerManager);
		}


		[Fact]
		public void Can_store_a_blog()
		{
			Model.Blog blog = new Blog();
			blogRepository.SaveBlog(blog);
			long id = objectContainer.GetID(blog);
			Assert.True(id > 0);
		}


		[Fact]
		public void Can_delete_the_entity()
		{
			Model.Blog blog = new Blog();
			blogRepository.DeleteBlog(blog);
			long id = objectContainer.GetID(blog);
			Assert.True(id == 0);
		}
	}
}