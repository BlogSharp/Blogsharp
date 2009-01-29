using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Db4o.Repositories;
using BlogSharp.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;
using Model = BlogSharp.Model;
namespace BlogSharp.Db4o.Tests.Repositories
{
	public class BlogRepositoryTests:BaseTest
	{
		public BlogRepositoryTests()
		{
			this.blogRepository = new BlogRepository(this.objectContainerManager);
		}

		private readonly IBlogRepository blogRepository;


		[Fact]
		public void Can_store_a_blog()
		{
			Model.Blog blog = new Blog();
			blogRepository.SaveBlog(blog);
			long id = this.objectContainer.GetID(blog);
			Assert.True(id > 0);
		}


		[Fact]
		public void Can_delete_the_entity()
		{
			Model.Blog blog = new Blog();
			blogRepository.DeleteBlog(blog);
			long id = this.objectContainer.GetID(blog);
			Assert.True(id ==0 );
		}
	}
}
