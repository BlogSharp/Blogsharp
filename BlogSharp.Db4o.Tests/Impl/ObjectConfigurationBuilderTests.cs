using BlogSharp.Db4o.Impl;
using NUnit.Framework;


namespace BlogSharp.Db4o.Tests.Impl
{
	[TestFixture]
	public class ObjectConfigurationBuilderTests : BaseTest
	{
		private IObjectServerConfigurationBuilder objectServerConfigurationBuilder;

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			objectServerConfigurationBuilder = new DefaultConfigurationBuilder();
		}

		[Test]
		public void Test_if_builder_can_return_configuration()
		{
			var configuration = objectServerConfigurationBuilder.GetConfiguration(null);
			Assert.NotNull(configuration);
		}
	}
}