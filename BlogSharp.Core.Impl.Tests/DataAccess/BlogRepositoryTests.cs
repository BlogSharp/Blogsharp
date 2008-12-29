using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.DataAccess;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Rhino.Mocks;
using Xunit;
using Model = BlogSharp.Model;
using MPost=BlogSharp.Model.Impl.Post;
namespace BlogSharp.Core.Impl.Tests.DataAccess
{
	public class BlogRepositoryTests:BaseTest
	{
		public BlogRepositoryTests()
		{
			this.objectContainer = MockRepository.GenerateMock<IObjectContainer>();
			this.blogRepository = new BlogRepository(this.objectContainer);
		}

		public override void  OnTearDown()
		{
			this.objectContainer.Close();
		}
		private readonly IObjectContainer objectContainer;
		private readonly IBlogRepository blogRepository;


		[Fact]
		public void Can_store_an_blog()
		{
			Model.IBlog blog = this.GetEntityFactory<Model.IBlog>().Create();
			blogRepository.SaveBlog(blog);
			this.objectContainer.AssertWasCalled(x => x.Store(blog));
			
		}


		[Fact]
		public void Can_delete_the_entity()
		{
			Model.IBlog blog = this.GetEntityFactory<Model.IBlog>().Create();
			blogRepository.DeleteBlog(blog);
			this.objectContainer.AssertWasCalled(x => x.Delete(blog));
		}

		//[Fact]
		//public void CanQuery()
		//{
		//    var result = postRepository.GetByExpression(x => x.FriendlyTitle.StartsWith("osman"));
		//    this.objectContainer.AssertWasCalled(x => x.Cast<Model.IPost>());
		//}
	}
}
