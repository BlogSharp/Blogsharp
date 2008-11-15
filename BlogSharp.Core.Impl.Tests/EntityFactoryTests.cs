using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;
using Castle.DynamicProxy;
using Xunit;

namespace BlogSharp.Core.Impl.Tests
{
	public interface IPost
	{
		IList<string> List { get; set; }
		string Content { get; set; }
	}
	public class EntityFactoryTests
	{
		public EntityFactoryTests()
		{
			this.postFactory = new EntityFactory<IPost>(new ProxyGenerator());
		}
		private readonly IEntityFactory<IPost> postFactory;
		[Fact]
		public void CanCreateEntity()
		{
			IPost post = postFactory.Create();
			Assert.NotNull(post);
		}


		[Fact]
		public void CanStoreValues()
		{
			IPost post = postFactory.Create();
			post.Content = "blah";
			Assert.Equal("blah",post.Content);
		}

		[Fact]
		public void CanCreateListAutomatically()
		{
			IPost post = postFactory.Create();
			post.List.Add("aaaa");
			post.List.Add("bbbb");
			Assert.Equal(2, post.List.Count);
		}
	}
}
