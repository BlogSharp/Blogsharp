namespace BlogSharp.Core.Impl.Tests
{
	using Castle.Windsor;
	using NUnit.Framework;

	/// <summary>
	/// The base of all tests.
	/// </summary>
	public class BaseTest
	{
		/// <summary>
		/// The IOC container.
		/// </summary>
		private IWindsorContainer container;

		/// <summary>
		/// The SetUp for all tests.
		/// </summary>
		[SetUp]
		public virtual void SetUp()
		{
			container = new WindsorContainer();
		}

		/// <summary>
		/// The Tear Down (destruct) of all tests.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			OnTearDown();
			if (container != null)
			{
				container.Dispose();
			}
		}

		/// <summary>
		/// method called to allow to each test to handle his own tear down.
		/// </summary>
		public virtual void OnTearDown()
		{
		}
	}
}