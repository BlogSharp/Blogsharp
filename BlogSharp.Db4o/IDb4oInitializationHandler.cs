namespace BlogSharp.Db4o
{
	using Db4objects.Db4o.Ext;

	public interface IDb4oInitializationHandler
	{
		void HandleObjectContainerCreated(IExtObjectContainer extObjectContainer);
	}
}