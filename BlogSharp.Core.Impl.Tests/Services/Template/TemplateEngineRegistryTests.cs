using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.Template;
using NUnit.Framework;
using Rhino.Mocks;

namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	[TestFixture]
	public class TemplateEngineRegistryTests
	{
		private ITemplateEngineRegistry templateEngineRegistry;

		[SetUp]
		public void SetUp()
		{
			templateEngineRegistry = new TemplateEngineRegistry();
		}


		[Test]
		public void Can_register_key_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			Assert.That(templateEngineRegistry.GetTemplateEngine("blah"),Is.EqualTo(mock));
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