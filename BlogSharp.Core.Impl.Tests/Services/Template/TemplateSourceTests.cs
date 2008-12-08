using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.FileSystem;
using BlogSharp.Core.Services.Template;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Services.Template
{
	public class TemplateSourceTests
	{
		public TemplateSourceTests()
		{
			this.fileService = MockRepository.GenerateMock<IFileService>();
			this.templateEngineRegistry = MockRepository.GenerateMock<ITemplateEngineRegistry>();
			this.templateSource = new DefaultTemplateSource(fileService, templateEngineRegistry);
		}

		private readonly IFileService fileService;
		private readonly ITemplateSource templateSource;
		private readonly ITemplateEngineRegistry templateEngineRegistry;

		[Fact]
		public void Can_get_template_from_from_file_and_sets_correct_template_engine()
		{
			string file = "#templateengine(spark)\nyet another team";
			Stream fileStream = new MemoryStream();
			StreamWriter sw = new StreamWriter(fileStream);
			sw.Write(file);
			sw.Flush();
			fileStream.Position = 0;

			string fileName = "blah";
			IFile fileMock = MockRepository.GenerateMock<IFile>();
			fileMock.Expect(x => x.OpenRead()).Return(fileStream);
			fileService.Expect(x => x.GetFile(fileName)).Return(fileMock);
			
			ITemplate template = this.templateSource.GetTemplateFromFile("blah");
			templateEngineRegistry.AssertWasCalled(x=>x.GetTemplateEngine("spark"));
			Assert.Equal("yet another team",template.GetContent());
		}

		[Fact]
		public void Can_get_template_from_from_content_and_sets_correct_template_engine()
		{
			string content = "#templateengine(spark)\nyet another team";
			ITemplate template = this.templateSource.GetTemplateFromString(content);
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.Equal("yet another team", template.GetContent());
		}


		[Fact]
		public void Can_register_with_file()
		{
			string file = "#templateengine(spark)\nyet another team";
			Stream fileStream = new MemoryStream();
			StreamWriter sw = new StreamWriter(fileStream);
			sw.Write(file);
			sw.Flush();
			fileStream.Position = 0;

			string fileName = "blah";
			IFile fileMock = MockRepository.GenerateMock<IFile>();
			fileMock.Expect(x => x.OpenRead()).Return(fileStream);
			fileService.Expect(x => x.GetFile(fileName)).Return(fileMock);


			this.templateSource.RegisterTemplateWithFile("mail", "blah");
			ITemplate template = this.templateSource.GetTemplateWithKey("mail");
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.Equal("yet another team", template.GetContent());
		}

		[Fact]
		public void Can_register_with_content()
		{
			string content = "#templateengine(spark)\nyet another team";
			this.templateSource.RegisterTemplateWithString("blah",content);
			ITemplate template = this.templateSource.GetTemplateWithKey("blah");
			templateEngineRegistry.AssertWasCalled(x => x.GetTemplateEngine("spark"));
			Assert.Equal("yet another team", template.GetContent());
		}
	}
}
