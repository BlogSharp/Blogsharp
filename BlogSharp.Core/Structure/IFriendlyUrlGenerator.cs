using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Structure
{
	public interface IFriendlyUrlGenerator
	{
		string GenerateUrl(string format, params string[] args);
	}
}
