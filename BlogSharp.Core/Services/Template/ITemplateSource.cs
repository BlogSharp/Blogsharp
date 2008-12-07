using System.IO;
namespace BlogSharp.Core.Services.Template
{
	public interface ITemplateSource
	{
		ITemplate GetTemplateFromFile(string file);
		ITemplate GetTemplateFromFile(Stream file);
		ITemplate GetTemplateWithKey(string key);
	}
}
