using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;

namespace BlogSharp.Db4o
{
	public interface IObjectContainerWrapper
	{
		IExtObjectContainer Wrap(IExtObjectContainer realSession, ObjectContainerCloseDelegate closeDelegate, ObjectContainerDisposeDelegate disposeDelegate);
		bool IsWrapped(IObjectContainer session);
		IExtObjectContainer UnWrap(IObjectContainer wrapped);
	}
}
