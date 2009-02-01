using System.Collections.Generic;
using System.IO;
using BlogSharp.Core.Impl.Services.Template.NVelocity;
using BlogSharp.Core.Services.Template;
using NVelocity.App;
using Rhino.Mocks;
using NUnit.Framework;

namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	[TestFixture]
	public class VelocityTemplateEngineTests
	{
		private ITemplateEngine velocityEngine;

		[SetUp]
		public void SetUp()
		{
			velocityEngine = new NVelocityTemplateEngine(new VelocityEngine());
		}

		[Test]
		public void NVelocity_can_merge_template_with_context()
		{
			ITemplate template = MockRepository.GenerateStub<ITemplate>();
			template.Expect(x => x.GetContent()).Return("$person.Name");
			var context = new Dictionary<string, object>();
			context["person"] = new {Name = "Mahmut"};
			StringWriter sw = new StringWriter();
			velocityEngine.Merge(template, context, sw);
			Assert.AreEqual("Mahmut", sw.GetStringBuilder().ToString());
		}
	}
}