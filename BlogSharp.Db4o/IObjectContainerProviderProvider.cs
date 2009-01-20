using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
