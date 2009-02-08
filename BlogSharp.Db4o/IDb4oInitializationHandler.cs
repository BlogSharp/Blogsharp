using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o
{
	public interface IDb4oInitializationHandler
	{
		void HandleObjectContainerCreated(IExtObjectContainer extObjectContainer);
	}
}
