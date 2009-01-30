using System.Collections.Generic;
using System.IO;

namespace BlogSharp.Core.Services.Template
{
	public interface ITemplateEngine
	{
		void Merge(ITemplate template, IDictionary<string, object> context, TextWriter output);
		string Merge(ITemplate template, IDictionary<string, object> context);
	}
}