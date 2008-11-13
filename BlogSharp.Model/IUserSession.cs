using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface IUserSession:IIdentifiable<int>
	{
		string Guid { get; set; }
		IList<string> Ips { get; set; }
	}
}
