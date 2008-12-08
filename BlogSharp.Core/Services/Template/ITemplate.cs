using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Template
{
	public interface ITemplate
	{
		string GetContent();
		ITemplateEngine Engine { get; }
	}
}
