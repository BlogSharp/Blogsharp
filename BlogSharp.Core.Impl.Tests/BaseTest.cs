using System;
using System.IO;
using BlogSharp.Model;
using BlogSharp.Model.Impl;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Rhino.Mocks;

namespace BlogSharp.Core.Impl.Tests
{
	public class BaseTest:IDisposable
	{
		public BaseTest()
		{
			this.container = new WindsorContainer();
			this.container.Register(Component.For<IPost>().ImplementedBy<Post>().LifeStyle.Transient);
			this.container.Register(Component.For<IBlog>().ImplementedBy<Blog>().LifeStyle.Transient);
			this.container.Register(Component.For<IPostComment>().ImplementedBy<PostComment>().LifeStyle.Transient);
			this.container.Register(Component.For<ITag>().ImplementedBy<Tag>().LifeStyle.Transient);
			this.container.Register(Component.For<IUser>().ImplementedBy<Author>().LifeStyle.Transient);
			this.container.Register(Component.For(typeof(IEntityFactory<>)).ImplementedBy(typeof(DIEntityFactory<>)).LifeStyle.Transient);
			DI.SetContainer(this.container);
		}
		private readonly IWindsorContainer container;
		protected virtual IEntityFactory<T> GetEntityFactory<T>() where T:class
		{
			return this.container.Resolve<IEntityFactory<T>>();
		}

		public virtual void OnTearDown()
		{
			
		}
        
		#region IDisposable Members

		public void Dispose()
		{
			OnTearDown();
		}

		#endregion
	}
}
