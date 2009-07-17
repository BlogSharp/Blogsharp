namespace BlogSharp.CastleExtensions.Tests.Facilities
{
	using Castle.MicroKernel.Registration;
	using Castle.Windsor;
	using CastleExtensions.Facilities.EnrichFacility;
	using NUnit.Framework;

	[TestFixture]
	public class EnrichWithFacilityTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			container = new WindsorContainer();
			container.AddFacility<EnrichWithFacility>();
		}

		#endregion

		private WindsorContainer container;

		[Test]
		public void CanEnrich_when_singleton()
		{
			container.Register(Component.For<IService>().ImplementedBy<MyService>()
			                   	.EnrichWith((kernel, instance) => ((IService) instance).I++));
			var service = container.Resolve<IService>();
			Assert.That(service.I, Is.EqualTo(1));
			service = container.Resolve<IService>();
			Assert.That(service.I, Is.EqualTo(1));
		}

		[Test]
		public void CanEnrich_when_transient()
		{
			container.Register(Component.For<IService2>().ImplementedBy<MyService2>()
			                   	.LifeStyle.Transient.EnrichWith((kernel, instance) => ((IService2) instance).I++));
			var service = container.Resolve<IService2>();
			Assert.That(service.I, Is.EqualTo(1));
			service = container.Resolve<IService2>();
			Assert.That(service.I, Is.EqualTo(2));
		}
	}

	public interface IService
	{
		int I { get; set; }
	}

	public class MyService : IService
	{
		#region IService Members

		public int I { get; set; }

		#endregion
	}


	public interface IService2
	{
		int I { get; set; }
	}

	public class MyService2 : IService2
	{
		private static int x;

		#region IService2 Members

		public int I
		{
			get { return x; }
			set { x = value; }
		}

		#endregion
	}
}