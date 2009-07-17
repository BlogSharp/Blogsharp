namespace BlogSharp.Core.Impl.Services.Template
{
	using System.Collections.Generic;
	using Core.Services.Template;

	public class TemplateEngineRegistry : ITemplateEngineRegistry
	{
		private readonly IDictionary<string, ITemplateEngine> keyToTemplateEngine;

		public TemplateEngineRegistry()
		{
			keyToTemplateEngine = new Dictionary<string, ITemplateEngine>();
		}

		#region ITemplateEngineRegistry Members

		public void RegisterTemplateEngine(string key, ITemplateEngine engine)
		{
			keyToTemplateEngine[key] = engine;
		}

		public void UnregisterTemplateEngine(string key)
		{
			keyToTemplateEngine.Remove(key);
		}

		public ITemplateEngine GetTemplateEngine(string key)
		{
			ITemplateEngine engine = null;
			keyToTemplateEngine.TryGetValue(key, out engine);
			return engine;
		}

		#endregion
	}
}