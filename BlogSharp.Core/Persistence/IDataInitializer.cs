using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.Persistence
{
	public interface IDataInitializer
	{
		bool ShouldRun(Blog blog);
		void Run(Blog blog);
	}
}
