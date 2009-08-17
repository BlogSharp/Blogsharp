namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	using Core.Services.Template;
	using Impl.Services.Template;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class TemplateEngineRegistryTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			templateEngineRegistry = new TemplateEngineRegistry();
		}

		#endregion

		private ITemplateEngineRegistry templateEngineRegistry;


		[Test]
		public void Can_register_key_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			Assert.That(templateEngineRegistry.GetTemplateEngine("blah"), Is.EqualTo(mock));
		}

		[Test]
		public void Can_unregister_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			templateEngineRegistry.UnregisterTemplateEngine("blah");
			Assert.Null(templateEngineRegistry.GetTemplateEngine("blah"));
		}
	}
}