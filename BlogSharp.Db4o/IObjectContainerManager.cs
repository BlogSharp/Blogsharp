using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace BlogSharp.Db4o
{
	public interface IObjectContainerManager
	{
		IObjectContainer GetContainer();
		IObjectContainer GetContainer(string alias);
	}
}
