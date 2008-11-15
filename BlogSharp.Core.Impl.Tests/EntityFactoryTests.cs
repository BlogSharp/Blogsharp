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
		[Fact]
		public void CanCreateEntity()
		{
			IEntityFactory<IPost> postFactory = new EntityFactory<IPost>(new ProxyGenerator());
			IPost post = postFactory.Create();
			Assert.NotNull(post);
		}


		[Fact]
		public void CanStoreValues()
		{
			IEntityFactory<IPost> postFactory = new EntityFactory<IPost>(new ProxyGenerator());
			IPost post = postFactory.Create();
			post.Content = "blah";
			Assert.Equal("blah",post.Content);
		}

		[Fact]
		public void CanCreateListAutomatically()
		{
			IEntityFactory<IPost> postFactory = new EntityFactory<IPost>(new ProxyGenerator());
			IPost post = postFactory.Create();
			post.List.Add("aaaa");
			Assert.Equal(1, post.List.Count);
		}
	}
}
