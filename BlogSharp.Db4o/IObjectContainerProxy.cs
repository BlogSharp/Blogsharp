namespace BlogSharp.Db4o
{
	using Db4objects.Db4o;
	using Impl;

	public interface IObjectContainerProxy
	{
		TransactionProtectionInterceptor InvocationHandler { get; }
		IObjectContainer InnerContainer { get; }
	}
}