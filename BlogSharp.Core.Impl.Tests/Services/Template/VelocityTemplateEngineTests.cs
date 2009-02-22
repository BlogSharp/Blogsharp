namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	using System.Collections.Generic;
	using System.IO;
	using Core.Services.Template;
	using Impl.Services.Template.NVelocity;
	using NUnit.Framework;
	using NVelocity.App;
	using Rhino.Mocks;

	[TestFixture]
	public class VelocityTemplateEngineTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.velocityEngine = new NVelocityTemplateEngine(new VelocityEngine());
		}

		#endregion

		private ITemplateEngine velocityEngine;

		[Test]
		public void NVelocity_can_merge_template_with_context()
		{
			ITemplate template = MockRepository.GenerateStub<ITemplate>();
			template.Expect(x => x.GetContent()).Return("$person.Name");
			var context = new Dictionary<string, object>();
			context["person"] = new {Name = "Mahmut"};
			StringWriter sw = new StringWriter();
			this.velocityEngine.Merge(template, context, sw);
			Assert.AreEqual("Mahmut", sw.GetStringBuilder().ToString());
		}
	}
}