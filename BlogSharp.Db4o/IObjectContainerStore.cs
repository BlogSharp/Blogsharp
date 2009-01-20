using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o
{
	public interface IObjectContainerStore
	{
		IExtObjectContainer this[string alias] { get; set; }
		IDictionary<string, IExtObjectContainer> Dictionary { get; }
	}
}
