namespace BlogSharp.Db4o.Tests.Repositories
{
	using Blog.Repositories;
	using Core.Persistence.Repositories;
	using NUnit.Framework;

	[TestFixture]
	public class BlogRepositoryTests : BaseTest
	{
		#region Setup/Teardown

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.blogRepository = new BlogRepository(this.objectContainerManager);
		}

		#endregion

		private IBlogRepository blogRepository;


		[Test]
		public void Can_delete_the_entity()
		{
			Model.Blog blog = new BlogSharp.Model.Blog();
			this.blogRepository.DeleteBlog(blog);
			long id = this.objectContainer.GetID(blog);
			Assert.True(id == 0);
		}

		[Test]
		public void Can_store_a_blog()
		{
			Model.Blog blog = new BlogSharp.Model.Blog();
			this.blogRepository.SaveBlog(blog);
			long id = this.objectContainer.GetID(blog);
			Assert.True(id > 0);
		}
	}
}