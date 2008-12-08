using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.Services.Template
{
	public class DefaultTemplate:ITemplate
	{
		public DefaultTemplate(string content,ITemplateEngine engine)
		{
			this.content = content;
			this.engine = engine;
			
		}
		#region ITemplate Members

		public string GetContent()
		{
			return content;
		}

		private readonly string content;


		public ITemplateEngine Engine
		{
			get { return this.engine; }
		}

		private readonly ITemplateEngine engine;
		#endregion
	}
}
