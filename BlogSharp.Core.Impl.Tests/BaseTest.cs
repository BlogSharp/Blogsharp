using System;
using Castle.Windsor;

namespace BlogSharp.Core.Impl.Tests
{
	public class BaseTest : IDisposable
	{
		private readonly IWindsorContainer container;

		public BaseTest()
		{
			container = new WindsorContainer();
		}

		#region IDisposable Members

		public void Dispose()
		{
			OnTearDown();
		}

		#endregion

		public virtual void OnTearDown()
		{
		}
	}
}