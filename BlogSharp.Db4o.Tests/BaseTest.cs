using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlogSharp.Core;
using BlogSharp.Core.Impl;
using BlogSharp.Model;
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
			DI.SetContainer(this.container);
			IConfiguration configuration = Db4oFactory.NewConfiguration();
			this.objectContainer = Db4oFactory.OpenFile(configuration, DB4O_FILE_NAME).Ext();
			this.objectContainerManager = new TestObjectContainerManager(this.objectContainer);
		}
		private readonly IWindsorContainer container;
		protected readonly TestObjectContainerManager objectContainerManager;
		protected readonly IExtObjectContainer objectContainer;

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