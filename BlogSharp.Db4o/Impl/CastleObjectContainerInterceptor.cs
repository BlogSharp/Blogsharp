namespace BlogSharp.Db4o.Impl
{
	using System;
	using System.Reflection;
	using Castle.Core.Interceptor;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;

	public class CastleObjectContainerInterceptor : TransactionProtectionInterceptor, IInterceptor
	{
		public CastleObjectContainerInterceptor(IObjectContainer container, ObjectContainerCloseDelegate closeDelegate,
		                                        ObjectContainerDisposeDelegate disposeDelegate)
			: base(container, closeDelegate, disposeDelegate)
		{
		}

		#region IInterceptor Members

		public void Intercept(IInvocation invocation)
		{
			invocation.ReturnValue = null;
			try
			{
				bool proceed;
				object returnValue = base.Invoke(invocation.Method, invocation.Arguments, out proceed);
				if (returnValue == this.container)
					returnValue = invocation.Proxy as IExtObjectContainer;
				// Avoid invoking the actual implementation
				if (!proceed)
				{
					invocation.ReturnValue = returnValue;
				}
				else
				{
					invocation.Proceed();
				}
			}
			catch (MethodAccessException ex)
			{
				throw ex;
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		#endregion
	}
}