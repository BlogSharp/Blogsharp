using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BlogSharp.Core.Services.FileSystem;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.Services.Template
{
	//TODO: Very naive implementation! Be cautious.
	public class DefaultTemplateSource:ITemplateSource
	{

		private readonly IFileService fileServices;
		private readonly ITemplateEngineRegistry templateEngineRegistry;
		private static readonly Regex REGEX_TEMPLATEENGINEKEY = new Regex(@"^#templateengine\((?<key>\w+)\)");
		private readonly IDictionary<string, Func<ITemplate>> keyToTemplate;


		public DefaultTemplateSource(IFileService fileServices,ITemplateEngineRegistry templateEngineRegistry)
		{
			this.fileServices = fileServices;
			this.templateEngineRegistry = templateEngineRegistry;
			this.keyToTemplate=new Dictionary<string, Func<ITemplate>>();
		}

		public ITemplate GetTemplateFromFile(string file)
		{
			string output;
			using (var stream = this.fileServices.OpenFileForRead(file))
			{
				using (var reader = new StreamReader(stream))
				{
					output = reader.ReadToEnd();
					reader.Close();
				}
				stream.Close();
			}
			return this.GetTemplateFromString(output);
		}
		public ITemplate GetTemplateWithKey(string key)
		{
			return this.keyToTemplate[key]();
		}
		public ITemplate GetTemplateFromString(string content)
		{

			Match m = REGEX_TEMPLATEENGINEKEY.Match(content);
			if (m.Success)
			{
				string engineKey = m.Groups["key"].Value;
				ITemplateEngine engine = this.templateEngineRegistry.GetTemplateEngine(engineKey);
				return new DefaultTemplate(content.Substring(m.Index+m.Length+1), engine);
			}
			else
			{
				return new DefaultTemplate(content, new NullTemplateEngine());
			}
		}



		#region ITemplateSource Members
		public void RegisterTemplateWithFile(string key, string file)
		{
			this.keyToTemplate[key] = () => GetTemplateFromFile(file);
		}

		public void RegisterTemplateWithString(string key, string content)
		{
			this.keyToTemplate[key] = () => GetTemplateFromString(content);
		}

		public void UnregisterTemplate(string key)
		{
			this.keyToTemplate.Remove(key);
		}

		#endregion
	}
}
