using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.Internal;

namespace BlogSharp.Db4o.Impl
{
	public class CastleObjectContainerWrapper:IObjectContainerWrapper
	{
		private readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

		#region Implementation of ISessionWrapper
		public IExtObjectContainer Wrap(IExtObjectContainer realContainer, ObjectContainerCloseDelegate closeDelegate, ObjectContainerDisposeDelegate disposeDelegate)
		{
			var privateRevealer = new Db4oWrapper(realContainer);
			var wrapper = new CastleObjectContainerInterceptor(realContainer, closeDelegate, disposeDelegate);
			var wrapped =
				(IExtObjectContainer)
				proxyGenerator.CreateInterfaceProxyWithTarget(typeof(IExtObjectContainer),
				                                              new Type[]
				                                              	{ 
																	typeof(IExtObjectContainer),
																	typeof (IObjectContainerProxy),
				                                              		typeof (IObjectContainer)
				                                              	},
															  privateRevealer, wrapper);
			return wrapped;
		}

		public IExtObjectContainer UnWrap(IObjectContainer wrapped)
		{
			IProxyTargetAccessor proxy = wrapped as IProxyTargetAccessor;

			return (proxy.DynProxyGetTarget() as Db4oWrapper).inner;
		}

		public bool IsWrapped(IObjectContainer container)
		{
			if (container == null)
			{
				return false;
			}
			var sessionProxy = container as IObjectContainerProxy;
			return sessionProxy != null && sessionProxy.InvocationHandler != null
			       && sessionProxy.InvocationHandler is TransactionProtectionInterceptor;
		}

		#endregion


	}
}
