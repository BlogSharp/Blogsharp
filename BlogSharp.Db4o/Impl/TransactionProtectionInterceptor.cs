using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.Core.Interceptor;
using Db4objects.Db4o;

namespace BlogSharp.Db4o.Impl
{
	public delegate void ObjectContainerCloseDelegate(IObjectContainer container);
	public delegate void ObjectContainerDisposeDelegate(IObjectContainer container);
	public abstract class TransactionProtectionInterceptor
	{
		public TransactionProtectionInterceptor(
			IObjectContainer container,
			ObjectContainerCloseDelegate close, 
			ObjectContainerDisposeDelegate dispose)
		{
			this.closeDelegate = close;
			this.disposeDelegate = dispose;
			this.container = container;
		}
		protected readonly static object InvokeImplementation=new object();
		protected readonly IObjectContainer container;
		protected readonly ObjectContainerCloseDelegate closeDelegate;
		protected readonly ObjectContainerDisposeDelegate disposeDelegate;
		public virtual object Invoke(MethodBase methodInfo,object[] args,out bool proceed)
		{
			string methodName = methodInfo.Name;
			if (methodName.Equals("get_InvocationHandler"))
			{
				proceed = false;
				return this;
			}
			else if(methodName.Equals("get_InnerContainer"))
			{
				proceed = false;
				return this.container;
			}
			else if (methodName.Equals("Ext"))
			{
				proceed = false;
				return this.container;
			}	
			else if (methodName.Equals("Close"))
			{
				proceed = false;
				if (closeDelegate != null)
					closeDelegate(this.container);
				return false;
			}
			else if (methodName.Equals("Dispose"))
			{
				proceed = false;
				if (closeDelegate != null)
					closeDelegate(this.container);
				if (disposeDelegate != null)
					disposeDelegate(this.container);
				return null;
			}
			else
				proceed = true;
			return InvokeImplementation;
		}
	}
}
