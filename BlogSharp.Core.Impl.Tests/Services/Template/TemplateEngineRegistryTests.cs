using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.Template;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	public class TemplateEngineRegistryTests
	{
		private readonly ITemplateEngineRegistry templateEngineRegistry;

		public TemplateEngineRegistryTests()
		{
			templateEngineRegistry = new TemplateEngineRegistry();
		}


		[Fact]
		public void Can_register_key_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			Assert.Equal(mock, templateEngineRegistry.GetTemplateEngine("blah"));
		}

		[Fact]
		public void Can_unregister_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			templateEngineRegistry.UnregisterTemplateEngine("blah");
			Assert.Null(templateEngineRegistry.GetTemplateEngine("blah"));
		}
	}
}