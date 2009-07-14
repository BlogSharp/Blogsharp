namespace BlogSharp.CastleExtensions.Tests.DependencyResolvers
{
    using Castle.MicroKernel.Handlers;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using CastleExtensions.DependencyResolvers;
    using NUnit.Framework;
    
    /// <summary>
    /// Sample service 1
    /// </summary>
    public class SampleService1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleService1" /> class. 
        /// </summary>
        /// <param name="serviceId">The service ID</param>
        public SampleService1(string serviceId)
        {
            this.ServiceId = serviceId;
        }

        /// <summary>
        /// Gets or sets ServiceId.
        /// </summary>
        public string ServiceId { get; set; }
    }
    
    /// <summary>
    /// Sample service 2
    /// </summary>
    public class SampleService2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleService2" /> class. 
        /// </summary>
        /// <param name="serviceId">The service ID</param>
        public SampleService2(string serviceId)
        {
            this.ServiceId = serviceId;
        }

        /// <summary>
        /// Gets or sets ServiceId.
        /// </summary>
        public string ServiceId { get; set; }
    }

    /// <summary>
    /// Sample service 3
    /// </summary>    
    public class SampleService3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleService3" /> class. 
        /// </summary>
        /// <param name="serviceId">The service ID</param>
        public SampleService3(int serviceId)
        {
            this.ServiceId = serviceId;
        }

        /// <summary>
        /// Gets or sets ServiceId.
        /// </summary>
        public int ServiceId { get; set; }
    }

    /// <summary>
    /// Tests the service resolver.
    /// </summary>
    [TestFixture]
    public class ServiceIdResolverTests
    {
        /// <summary>
        /// The IOC Container
        /// </summary>
        private IWindsorContainer container;

        #region Setup/Teardown

        /// <summary>
        /// Sets Up the testing environment.
        /// </summary>
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

        /// <summary>
        /// Attempts to resolve the service dependences.
        /// </summary>
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