using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Web.Modules
{
	public interface IBlogSharpHttpModule
	{
		void Start();
		void Stop();
	}
}
