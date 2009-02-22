namespace BlogSharp.Core.Impl.Services.Template.NVelocity
{
	using System.Collections.Generic;
	using System.IO;
	using Core.Services.Template;
	using global::NVelocity.App;

	public class NVelocityTemplateEngine : ITemplateEngine
	{
		private readonly VelocityEngine velocityEngine;

		public NVelocityTemplateEngine(VelocityEngine velocityEngine)
		{
			this.velocityEngine = velocityEngine;
			velocityEngine.Init();
		}

		#region ITemplateEngine Members

		public void Merge(ITemplate template, IDictionary<string, object> context, TextWriter output)
		{
			var ncontext = new global::NVelocity.VelocityContext();
			foreach (var pair in context)
			{
				ncontext.Put(pair.Key, pair.Value);
			}
			this.velocityEngine.Evaluate(ncontext, output, "merger", template.GetContent());
		}

		public string Merge(ITemplate template, IDictionary<string, object> context)
		{
			var ncontext = new global::NVelocity.VelocityContext();
			foreach (var pair in context)
			{
				ncontext.Put(pair.Key, pair.Value);
			}
			StringWriter sw = new StringWriter();
			this.velocityEngine.Evaluate(ncontext, sw, "merger", template.GetContent());
			return sw.GetStringBuilder().ToString();
		}

		#endregion
	}
}