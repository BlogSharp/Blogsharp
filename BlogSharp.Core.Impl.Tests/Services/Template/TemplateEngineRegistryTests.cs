using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.Template;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	public class TemplateEngineRegistryTests
	{
		public TemplateEngineRegistryTests()
		{
			this.templateEngineRegistry = new TemplateEngineRegistry();
		}

		private readonly ITemplateEngineRegistry templateEngineRegistry;


		[Fact]
		public void Can_register_key_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			this.templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			Assert.Equal(mock,this.templateEngineRegistry.GetTemplateEngine("blah"));
		}

		[Fact]
		public void Can_unregister_using_key()
		{
			var mock = MockRepository.GenerateMock<ITemplateEngine>();
			this.templateEngineRegistry.RegisterTemplateEngine("blah", mock);
			this.templateEngineRegistry.UnregisterTemplateEngine("blah");
			Assert.Null(this.templateEngineRegistry.GetTemplateEngine("blah"));
		}
	}
	
}
