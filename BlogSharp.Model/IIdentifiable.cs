using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface IIdentifiable<T>
	{
		T Id{ get; set; }
	}
}
