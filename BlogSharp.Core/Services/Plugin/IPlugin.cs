using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Plugin
{
	public interface IPlugin
	{
		void Start();
		void Stop();
		void Install();
		void UnInstall();
	}
}
