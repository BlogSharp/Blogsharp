namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	using System.IO;
	using Core.Services.FileSystem;
	using Core.Services.Template;
	using Impl.Services.Template;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class TemplateSourceTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.fileService = MockRepository.GenerateMock<IFileService>();
			this.templateEngineRegistry = MockRepository.GenerateMock<ITemplateEngineRegistry>();
			this.templateSource = new DefaultTemplateSource(this.fileService, this.templateEngineRegistry);
		}

		#endregion

		private IFileService fileService;
		private ITemplateEngineRegistry templateEngineRegistry;
		private ITemplateSource templateSource;


		[Test]
		public void Can_get_template_from_from_content_and_sets_correct_template_engine()
		{
			string content = "#templateengine(spark)\nyet another team";
			ITemplate template = this.templateSource.GetTemplateFromString(content);
			this.templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.That(template.GetContent(), Is.EqualTo("yet another team"));
		}

		[Test]
		public void Can_get_template_from_from_file_and_sets_correct_template_engine()
		{
			string file = "#templateengine(spark)\nyet another team";
			Stream fileStream = new MemoryStream();
			StreamWriter sw = new StreamWriter(fileStream);
			sw.Write(file);
			sw.Flush();
			fileStream.Position = 0;

			string fileName = "blah";
			this.fileService.Expect(x => x.OpenFileForRead(fileName)).Return(fileStream);
			ITemplate template = this.templateSource.GetTemplateFromFile("blah");
			this.templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.That(template.GetContent(), Is.EqualTo("yet another team"));
		}


		[Test]
		public void Can_register_with_content()
		{
			string content = "#templateengine(spark)\nyet another team";
			this.templateSource.RegisterTemplateWithString("blah", content);
			ITemplate template = this.templateSource.GetTemplateWithKey("blah");
			this.templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.That(template.GetContent(), Is.EqualTo("yet another team"));
		}

		[Test]
		public void Can_register_with_file()
		{
			string file = "#templateengine(spark)\nyet another team";
			Stream fileStream = new MemoryStream();
			StreamWriter sw = new StreamWriter(fileStream);
			sw.Write(file);
			sw.Flush();
			fileStream.Position = 0;

			string fileName = "blah";
			this.fileService.Expect(x => x.OpenFileForRead(fileName)).Return(fileStream);


			this.templateSource.RegisterTemplateWithFile("mail", "blah");
			ITemplate template = this.templateSource.GetTemplateWithKey("mail");
			this.templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.That(template.GetContent(), Is.EqualTo("yet another team"));
		}
	}
}