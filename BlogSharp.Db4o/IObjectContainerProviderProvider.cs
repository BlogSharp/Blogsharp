using BlogSharp.Db4o.Impl;

namespace BlogSharp.Db4o
{
	public interface IObjectContainerProviderProvider
	{
		IObjectContainerProvider GetFactory(string alias);
		void AddProvider(string alias, IObjectContainerProvider provider);

		void RemoveProvider(string alias);
	}
}