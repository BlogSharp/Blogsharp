namespace BlogSharp.Db4o.Impl
{
	using System.Reflection;
	using Db4objects.Db4o;

	public delegate void ObjectContainerCloseDelegate(IObjectContainer container);

	public delegate void ObjectContainerDisposeDelegate(IObjectContainer container);

	public abstract class TransactionProtectionInterceptor
	{
		protected static readonly object InvokeImplementation = new object();
		protected readonly ObjectContainerCloseDelegate closeDelegate;
		protected readonly IObjectContainer container;
		protected readonly ObjectContainerDisposeDelegate disposeDelegate;

		public TransactionProtectionInterceptor(
			IObjectContainer container,
			ObjectContainerCloseDelegate close,
			ObjectContainerDisposeDelegate dispose)
		{
			closeDelegate = close;
			disposeDelegate = dispose;
			this.container = container;
		}

		public virtual object Invoke(MethodBase methodInfo, object[] args, out bool proceed)
		{
			string methodName = methodInfo.Name;
			if (methodName.Equals("get_InvocationHandler"))
			{
				proceed = false;
				return this;
			}
			else if (methodName.Equals("get_InnerContainer"))
			{
				proceed = false;
				return container;
			}
			else if (methodName.Equals("Ext"))
			{
				proceed = false;
				return container;
			}
			else if (methodName.Equals("Close"))
			{
				proceed = false;
				if (closeDelegate != null)
					closeDelegate(container);
				return false;
			}
			else if (methodName.Equals("Dispose"))
			{
				proceed = false;
				if (closeDelegate != null)
					closeDelegate(container);
				if (disposeDelegate != null)
					disposeDelegate(container);
				return null;
			}
			else
				proceed = true;
			return InvokeImplementation;
		}
	}
}