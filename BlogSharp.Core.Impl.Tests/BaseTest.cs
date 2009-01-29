using System;
using System.IO;
using BlogSharp.Model;
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
			DI.SetContainer(this.container);
		}
		private readonly IWindsorContainer container;


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
