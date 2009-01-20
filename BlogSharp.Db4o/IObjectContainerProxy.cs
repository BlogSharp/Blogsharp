using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;

namespace BlogSharp.Db4o
{
	public interface IObjectContainerProxy
	{
		TransactionProtectionInterceptor InvocationHandler { get; }
		IObjectContainer InnerContainer { get; }
	}
}
