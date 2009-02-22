namespace BlogSharp.Db4o
{
	using Impl;

	public interface IObjectContainerProviderProvider
	{
		IObjectContainerProvider GetFactory(string alias);
		void AddProvider(string alias, IObjectContainerProvider provider);

		void RemoveProvider(string alias);
	}
}