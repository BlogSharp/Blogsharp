namespace BlogSharp.CastleExtensions.Tests.DependencyResolvers
{
	using Castle.MicroKernel.Handlers;
	using Castle.MicroKernel.Registration;
	using Castle.Windsor;
	using CastleExtensions.DependencyResolvers;
	using NUnit.Framework;

	public class SampleService1
	{
		public SampleService1(string serviceId)
		{
			this.ServiceId = serviceId;
		}

		public string ServiceId { get; set; }
	}

	public class SampleService2
	{
		public SampleService2(string serviceId)
		{
			this.ServiceId = serviceId;
		}

		public string ServiceId { get; set; }
	}

	public class SampleService3
	{
		public SampleService3(int serviceId)
		{
			this.ServiceId = serviceId;
		}

		public int ServiceId { get; set; }
	}

	[TestFixture]
	public class ServiceIdResolverTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.container = new WindsorContainer();
			this.container.Kernel.Resolver.AddSubResolver(new ServiceIdResolver());
			this.container.Register(Component.For<SampleService1>().Named("service1"))
				.Register(Component.For<SampleService2>().Named("service2"))
				.Register(Component.For<SampleService3>().Named("service3"));
		}

		#endregion

		private IWindsorContainer container;

		[Test]
		public void CanResolveDependencyWithServiceId()
		{
			var s1 = this.container.Resolve<SampleService1>();
			var s2 = this.container.Resolve<SampleService2>();
			Assert.That("service1", Is.EqualTo(s1.ServiceId));
			Assert.That("service2", Is.EqualTo(s2.ServiceId));
			Assert.Throws<HandlerException>(() => this.container.Resolve<SampleService3>());
		}
	}
}