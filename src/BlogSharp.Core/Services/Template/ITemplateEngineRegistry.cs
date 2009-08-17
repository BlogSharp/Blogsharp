namespace BlogSharp.Core.Services.Template
{
	public interface ITemplateEngineRegistry
	{
		void RegisterTemplateEngine(string key, ITemplateEngine engine);
		void UnregisterTemplateEngine(string key);
		ITemplateEngine GetTemplateEngine(string key);
	}
}