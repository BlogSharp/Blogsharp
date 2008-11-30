using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BlogSharp.Model;
using Castle.DynamicProxy;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests
{
	public class EntityFactoryTests:BaseTest
	{
		public EntityFactoryTests()
		{
			this.windsorContainer = MockRepository.GenerateStub<IWindsorContainer>();
			DI.SetContainer(windsorContainer);
			this.entityFactory = new DIEntityFactory<IPost>();
		}

		private readonly IWindsorContainer windsorContainer;
		private readonly IEntityFactory<IPost> entityFactory;

		[Fact]
		public void CanCreateEntity()
		{
			entityFactory.Create();
			this.windsorContainer.AssertWasCalled(x=>x.Resolve<IPost>());
		}
	}
}
