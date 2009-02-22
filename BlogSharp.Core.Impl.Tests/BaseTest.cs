namespace BlogSharp.Core.Impl.Tests
{
	using Castle.Windsor;
	using NUnit.Framework;

	public class BaseTest
	{
		private IWindsorContainer container;

		[SetUp]
		public virtual void SetUp()
		{
			container = new WindsorContainer();
		}

		[TearDown]
		public void TearDown()
		{
			OnTearDown();
		}

		public virtual void OnTearDown()
		{
		}
	}
}