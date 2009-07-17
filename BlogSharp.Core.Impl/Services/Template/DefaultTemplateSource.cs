namespace BlogSharp.Core.Impl.Services.Template
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text.RegularExpressions;
	using Core.Services.FileSystem;
	using Core.Services.Template;

	//TODO: Very naive implementation! Be cautious.
	public class DefaultTemplateSource : ITemplateSource
	{
		private static readonly Regex REGEX_TEMPLATEENGINEKEY = new Regex(@"^#templateengine\((?<key>\w+)\)");
		private readonly IFileService fileServices;
		private readonly IDictionary<string, Func<ITemplate>> keyToTemplate;
		private readonly ITemplateEngineRegistry templateEngineRegistry;


		public DefaultTemplateSource(IFileService fileServices, ITemplateEngineRegistry templateEngineRegistry)
		{
			this.fileServices = fileServices;
			this.templateEngineRegistry = templateEngineRegistry;
			keyToTemplate = new Dictionary<string, Func<ITemplate>>();
		}

		#region ITemplateSource Members

		public ITemplate GetTemplateFromFile(string file)
		{
			string output;
			using (var stream = fileServices.OpenFileForRead(file))
			{
				using (var reader = new StreamReader(stream))
				{
					output = reader.ReadToEnd();
					reader.Close();
				}
				stream.Close();
			}
			return GetTemplateFromString(output);
		}

		public ITemplate GetTemplateWithKey(string key)
		{
			return keyToTemplate[key]();
		}

		public ITemplate GetTemplateFromString(string content)
		{
			Match m = REGEX_TEMPLATEENGINEKEY.Match(content);
			if (m.Success)
			{
				string engineKey = m.Groups["key"].Value;
				ITemplateEngine engine = templateEngineRegistry.GetTemplateEngine(engineKey);
				return new DefaultTemplate(content.Substring(m.Index + m.Length + 1), engine);
			}
			else
			{
				return new DefaultTemplate(content, new NullTemplateEngine());
			}
		}

		public void RegisterTemplateWithFile(string key, string file)
		{
			keyToTemplate[key] = () => GetTemplateFromFile(file);
		}

		public void RegisterTemplateWithString(string key, string content)
		{
			keyToTemplate[key] = () => GetTemplateFromString(content);
		}

		public void UnregisterTemplate(string key)
		{
			keyToTemplate.Remove(key);
		}

		#endregion
	}
}