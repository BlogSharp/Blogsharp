using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.Services.Template
{
	public class NullTemplateEngine:ITemplateEngine
	{
		#region ITemplateEngine Members

		public void Merge(ITemplate template, IDictionary<string,object> context, System.IO.TextWriter output)
		{
			output.Write(template.GetContent());
		}

		public string Merge(ITemplate template, IDictionary<string,object> context)
		{
			return template.GetContent();
		}

		#endregion
	}
}
