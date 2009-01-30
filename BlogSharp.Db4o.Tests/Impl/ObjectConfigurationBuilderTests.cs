using BlogSharp.Db4o.Impl;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class ObjectConfigurationBuilderTests : BaseTest
	{
		private readonly IObjectServerConfigurationBuilder objectServerConfigurationBuilder;

		public ObjectConfigurationBuilderTests()
		{
			objectServerConfigurationBuilder = new DefaultConfigurationBuilder();
		}

		[Fact]
		public void Test_if_builder_can_return_configuration()
		{
			var configuration = objectServerConfigurationBuilder.GetConfiguration(null);
			Assert.NotNull(configuration);
		}
	}
}