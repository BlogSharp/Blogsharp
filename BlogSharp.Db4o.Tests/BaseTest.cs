using System;
using System.IO;
using Castle.Windsor;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o.Tests
{
	public class BaseTest : IDisposable
	{
		protected const string DB4O_FILE_NAME = "db4o.yap";

		private readonly IWindsorContainer container;
		protected readonly IExtObjectContainer objectContainer;
		protected readonly TestObjectContainerManager objectContainerManager;

		public BaseTest()
		{
			File.Delete(DB4O_FILE_NAME);
			container = new WindsorContainer();
			IConfiguration configuration = Db4oFactory.NewConfiguration();
			objectContainer = Db4oFactory.OpenFile(configuration, DB4O_FILE_NAME).Ext();
			objectContainerManager = new TestObjectContainerManager(objectContainer);
		}

		#region IDisposable Members

		public void Dispose()
		{
			OnTearDown();
			objectContainer.Close();
			objectContainer.Dispose();

			File.Delete(DB4O_FILE_NAME);
		}

		#endregion

		public virtual void OnTearDown()
		{
		}
	}
}