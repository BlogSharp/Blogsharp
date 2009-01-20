using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlogSharp.Core;
using BlogSharp.Core.Impl;
using BlogSharp.Model;
using BlogSharp.Model.Impl;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.IO;
using Sharpen.IO;
using File=System.IO.File;

namespace BlogSharp.Db4o.Tests
{
	public class BaseTest : IDisposable
	{
		protected const string DB4O_FILE_NAME = "db4o.yap";
		public BaseTest()
		{
			File.Delete(DB4O_FILE_NAME);
			this.container = new WindsorContainer();
			this.container.Register(Component.For<IPost>().ImplementedBy<Post>().LifeStyle.Transient);
			this.container.Register(Component.For<IBlog>().ImplementedBy<Blog>().LifeStyle.Transient);
			this.container.Register(Component.For<IPostComment>().ImplementedBy<PostComment>().LifeStyle.Transient);
			this.container.Register(Component.For<ITag>().ImplementedBy<Tag>().LifeStyle.Transient);
			this.container.Register(Component.For<IUser>().ImplementedBy<Author>().LifeStyle.Transient);
			this.container.Register(Component.For(typeof(IEntityFactory<>)).ImplementedBy(typeof(DIEntityFactory<>)).LifeStyle.Transient);
			DI.SetContainer(this.container);
			IConfiguration configuration = Db4oFactory.NewConfiguration();
			this.objectContainer = Db4oFactory.OpenFile(configuration, DB4O_FILE_NAME).Ext();
			this.objectContainerManager = new TestObjectContainerManager(this.objectContainer);
		}
		private readonly IWindsorContainer container;
		protected readonly TestObjectContainerManager objectContainerManager;
		protected readonly IExtObjectContainer objectContainer;
		protected virtual IEntityFactory<T> GetEntityFactory<T>() where T : class
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
			this.objectContainer.Close();
			this.objectContainer.Dispose();

			File.Delete(DB4O_FILE_NAME);

		}

		#endregion
	}
}