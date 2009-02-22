namespace BlogSharp.Db4o.Tests.Impl
{
	using Db4o.Impl;
	using NUnit.Framework;

	[TestFixture]
	public class ObjectConfigurationBuilderTests : BaseTest
	{
		#region Setup/Teardown

		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.objectServerConfigurationBuilder = new DefaultConfigurationBuilder();
		}

		#endregion

		private IObjectServerConfigurationBuilder objectServerConfigurationBuilder;

		[Test]
		public void Test_if_builder_can_return_configuration()
		{
			var configuration = this.objectServerConfigurationBuilder.GetConfiguration(null);
			Assert.NotNull(configuration);
		}
	}
}