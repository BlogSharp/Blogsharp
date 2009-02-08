using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Db4o.Blog.Repositories;
using BlogSharp.Model;
using NUnit.Framework;

namespace BlogSharp.Db4o.Tests.Repositories
{
	[TestFixture]
	public class BlogRepositoryTests : BaseTest
	{
		private  IBlogRepository blogRepository;

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			blogRepository = new BlogRepository(objectContainerManager);
		}



		[Test]
		public void Can_store_a_blog()
		{
			Model.Blog blog = new BlogSharp.Model.Blog();
			blogRepository.SaveBlog(blog);
			long id = objectContainer.GetID(blog);
			Assert.True(id > 0);
		}


		[Test]
		public void Can_delete_the_entity()
		{
			Model.Blog blog = new BlogSharp.Model.Blog();
			blogRepository.DeleteBlog(blog);
			long id = objectContainer.GetID(blog);
			Assert.True(id == 0);
		}
	}
}
