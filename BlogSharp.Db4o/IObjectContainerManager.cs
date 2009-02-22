namespace BlogSharp.Db4o
{
	using Db4objects.Db4o;

	public interface IObjectContainerManager
	{
		IObjectContainer GetContainer();
		IObjectContainer GetContainer(string alias);
	}
}