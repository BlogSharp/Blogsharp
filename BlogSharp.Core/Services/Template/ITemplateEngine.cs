using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Template
{
	public interface ITemplateEngine
	{
		void Merge(ITemplate template, ITemplateContext context,TextWriter output);
		string Merge(ITemplate template, ITemplateContext context);
	}
}
