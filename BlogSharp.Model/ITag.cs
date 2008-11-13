using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface ITag:IIdentifiable<int>
	{
		string Name { get; set; }
	}
}
