using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Template;
using NVelocity.App;

namespace BlogSharp.Core.Impl.Services.Template.NVelocity
{
	public class NVelocityTemplateEngine:ITemplateEngine
	{
		public NVelocityTemplateEngine(VelocityEngine velocityEngine)
		{
			this.velocityEngine = velocityEngine;
			velocityEngine.Init();
		}

		private readonly VelocityEngine velocityEngine;
		#region ITemplateEngine Members

		public void Merge(ITemplate template, IDictionary<string,object> context,TextWriter output)
		{
			var ncontext=new global::NVelocity.VelocityContext();
			foreach (var pair in context)
			{
				ncontext.Put(pair.Key, pair.Value);
			}
			velocityEngine.Evaluate(ncontext, output, "merger",template.GetContent());
			
		}

		#endregion

		#region ITemplateEngine Members


		public string Merge(ITemplate template, IDictionary<string,object> context)
		{
			var ncontext = new global::NVelocity.VelocityContext();
			foreach (var pair in context)
			{
				ncontext.Put(pair.Key, pair.Value);
			}
			StringWriter sw = new StringWriter();
			velocityEngine.Evaluate(ncontext,sw, "merger", template.GetContent());
			return sw.GetStringBuilder().ToString();
		}

		#endregion
	}
}
