namespace BlogSharp.Db4o
{
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;
	using Impl;

	public interface IObjectContainerWrapper
	{
		IExtObjectContainer Wrap(IExtObjectContainer realSession, ObjectContainerCloseDelegate closeDelegate,
		                         ObjectContainerDisposeDelegate disposeDelegate);

		bool IsWrapped(IObjectContainer session);
		IExtObjectContainer UnWrap(IObjectContainer wrapped);
	}
}