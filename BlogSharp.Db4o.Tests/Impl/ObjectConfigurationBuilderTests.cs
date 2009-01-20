using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Db4o.Impl;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	
	public class ObjectConfigurationBuilderTests:BaseTest
	{
		public ObjectConfigurationBuilderTests()
		{
			this.objectServerConfigurationBuilder = new DefaultConfigurationBuilder();
		}

		private readonly IObjectServerConfigurationBuilder objectServerConfigurationBuilder;

		[Fact]
		public void Test_if_builder_can_return_configuration()
		{
			var configuration = objectServerConfigurationBuilder.GetConfiguration(null);
			Assert.NotNull(configuration);
		}
	}
}
