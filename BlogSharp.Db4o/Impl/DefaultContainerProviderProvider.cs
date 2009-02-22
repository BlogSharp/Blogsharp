namespace BlogSharp.Db4o.Impl
{
	using System.Collections.Generic;

	public class DefaultContainerProviderProvider : IObjectContainerProviderProvider
	{
		private readonly IDictionary<string, IObjectContainerProvider> providers;

		public DefaultContainerProviderProvider()
		{
			providers = new Dictionary<string, IObjectContainerProvider>();
		}

		#region IObjectContainerProviderProvider Members

		public void AddProvider(string alias, IObjectContainerProvider provider)
		{
			providers[alias] = provider;
		}

		public void RemoveProvider(string alias)
		{
			providers.Remove(alias);
		}

		public IObjectContainerProvider GetFactory(string alias)
		{
			IObjectContainerProvider provider;
			providers.TryGetValue(alias, out provider);
			return provider;
		}

		#endregion
	}
}