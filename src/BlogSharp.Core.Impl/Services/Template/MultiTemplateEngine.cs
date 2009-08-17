namespace BlogSharp.Core.Impl.Services.Template
{
	using System;
	using System.Collections.Generic;
	using Core.Services.Template;

	public class MultiTemplateEngine : ITemplateEngine
	{
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