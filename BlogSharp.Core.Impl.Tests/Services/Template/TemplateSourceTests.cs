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
			fileService = MockRepository.GenerateMock<IFileService>();
			templateEngineRegistry = MockRepository.GenerateMock<ITemplateEngineRegistry>();
			templateSource = new DefaultTemplateSource(fileService, templateEngineRegistry);
		}

		#endregion

		private IFileService fileService;
		private ITemplateEngineRegistry templateEngineRegistry;
		private ITemplateSource templateSource;


		[Test]
		public void Can_get_template_from_from_content_and_sets_correct_template_engine()
		{
			string content = "#templateengine(spark)\nyet another team";
			ITemplate template = templateSource.GetTemplateFromString(content);
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
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
			fileService.Expect(x => x.OpenFileForRead(fileName)).Return(fileStream);
			ITemplate template = templateSource.GetTemplateFromFile("blah");
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.That(template.GetContent(), Is.EqualTo("yet another team"));
		}


		[Test]
		public void Can_register_with_content()
		{
			string content = "#templateengine(spark)\nyet another team";
			templateSource.RegisterTemplateWithString("blah", content);
			ITemplate template = templateSource.GetTemplateWithKey("blah");
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
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
			fileService.Expect(x => x.OpenFileForRead(fileName)).Return(fileStream);


			templateSource.RegisterTemplateWithFile("mail", "blah");
			ITemplate template = templateSource.GetTemplateWithKey("mail");
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.That(template.GetContent(), Is.EqualTo("yet another team"));
		}
	}
}