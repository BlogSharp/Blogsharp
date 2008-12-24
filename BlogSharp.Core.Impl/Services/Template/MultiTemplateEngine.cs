using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.Services.Template
{
	public class MultiTemplateEngine:ITemplateEngine
	{
		public MultiTemplateEngine()
		{
			
		}
		#region ITemplateEngine Members

		public void Merge(ITemplate template, IDictionary<string, object> context, System.IO.TextWriter output)
		{
			throw new NotImplementedException();
		}

		public string Merge(ITemplate template, IDictionary<string, object> context)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
