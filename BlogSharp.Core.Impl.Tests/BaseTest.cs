using System;
using Castle.Windsor;
using NUnit.Framework;
namespace BlogSharp.Core.Impl.Tests
{
	public class BaseTest
	{
		private IWindsorContainer container;

		[SetUp]
		public virtual void SetUp()
		{
			container = new WindsorContainer();
		}

		#region IDisposable Members
		[TearDown]
		public void TearDown()
		{
			OnTearDown();
		}

		#endregion

		public virtual void OnTearDown()
		{
		}
	}
}