namespace BlogSharp.Core.Services.Template
{
	using System.Collections.Generic;
	using System.IO;

	public interface ITemplateEngine
	{
		void Merge(ITemplate template, IDictionary<string, object> context, TextWriter output);
		string Merge(ITemplate template, IDictionary<string, object> context);
	}
}