using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.CastleExtensions.DependencyResolvers;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Xunit;

namespace BlogSharp.CastleExtensions.Tests.DependencyResolvers
{
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
	public class ServiceIdResolverTests
	{
		public ServiceIdResolverTests()
		{
			this.container = new WindsorContainer();
			this.container.Kernel.Resolver.AddSubResolver(new ServiceIdResolver());
			this.container.Register(Component.For<SampleService1>().Named("service1"))
				.Register(Component.For<SampleService2>().Named("service2"))
				.Register(Component.For<SampleService3>().Named("service3"));
		}
		private readonly IWindsorContainer container;

		[Fact]
		public void CanResolveDependencyWithServiceId()
		{
			var s1 = container.Resolve<SampleService1>();
			var s2 = container.Resolve<SampleService2>();
			Assert.Equal("service1", s1.ServiceId);
			Assert.Equal("service2", s2.ServiceId);
			Assert.Throws<HandlerException>(() => container.Resolve<SampleService3>());
		}
	}
}