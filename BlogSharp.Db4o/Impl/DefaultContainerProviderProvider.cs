using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Db4o.Impl
{
	public class DefaultContainerProviderProvider:IObjectContainerProviderProvider
	{
		public DefaultContainerProviderProvider()
		{
			this.providers = new Dictionary<string, IObjectContainerProvider>();
		}

		private readonly IDictionary<string, IObjectContainerProvider> providers;

		public void AddProvider(string alias,IObjectContainerProvider provider)
		{
			this.providers[alias] = provider;
		}

		public void RemoveProvider(string alias)
		{
			this.providers.Remove(alias);
		}

		#region IObjectContainerProviderProvider Members

		public IObjectContainerProvider GetFactory(string alias)
		{
			IObjectContainerProvider provider;
			this.providers.TryGetValue(alias, out provider);
			return provider;
		}

		#endregion
	}
}
