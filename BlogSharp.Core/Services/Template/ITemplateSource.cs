namespace BlogSharp.Core.Services.Template
{
	public interface ITemplateSource
	{
		ITemplate GetTemplateFromFile(string file);
		ITemplate GetTemplateWithKey(string key);
		ITemplate GetTemplateFromString(string content);
		void RegisterTemplateWithString(string key, string content);
		void RegisterTemplateWithFile(string key, string file);
		void UnregisterTemplate(string key);
	}
}