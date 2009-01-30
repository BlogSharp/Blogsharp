using System.Collections.Generic;
using System.IO;
using BlogSharp.Core.Impl.Services.Template.NVelocity;
using BlogSharp.Core.Services.Template;
using NVelocity.App;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	public class VelocityTemplateEngineTests
	{
		private readonly ITemplateEngine velocityEngine;

		public VelocityTemplateEngineTests()
		{
			velocityEngine = new NVelocityTemplateEngine(new VelocityEngine());
		}

		[Fact]
		public void NVelocity_can_merge_template_with_context()
		{
			ITemplate template = MockRepository.GenerateStub<ITemplate>();
			template.Expect(x => x.GetContent()).Return("$person.Name");
			var context = new Dictionary<string, object>();
			context["person"] = new {Name = "Mahmut"};
			StringWriter sw = new StringWriter();
			velocityEngine.Merge(template, context, sw);
			Assert.Equal("Mahmut", sw.GetStringBuilder().ToString());
		}
	}
}