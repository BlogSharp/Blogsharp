namespace BlogSharp.Core.Impl.Services.Template
{
	using System.Collections.Generic;
	using Core.Services.Template;

	public class NullTemplateEngine : ITemplateEngine
	{
		#region ITemplateEngine Members

		public void Merge(ITemplate template, IDictionary<string, object> context, System.IO.TextWriter output)
		{
			output.Write(template.GetContent());
		}

		public string Merge(ITemplate template, IDictionary<string, object> context)
		{
			return template.GetContent();
		}

		#endregion
	}
}