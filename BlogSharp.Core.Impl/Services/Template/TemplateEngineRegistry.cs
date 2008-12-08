using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.Services.Template
{
	public class TemplateEngineRegistry:ITemplateEngineRegistry
	{
		public TemplateEngineRegistry()
		{
			this.keyToTemplateEngine=new Dictionary<string, ITemplateEngine>();
		}
		private readonly IDictionary<string, ITemplateEngine> keyToTemplateEngine;




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
			this.keyToTemplateEngine.TryGetValue(key, out engine);
			return engine;
		}
		#endregion
	}
}
