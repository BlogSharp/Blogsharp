using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace BlogSharp.Db4o.Impl
{
	public class DefaultConfigurationBuilder:IObjectServerConfigurationBuilder
	{
		#region IObjectServerConfigurationBuilder Members

		public virtual Db4objects.Db4o.Config.IConfiguration GetConfiguration(Castle.Core.Configuration.IConfiguration config)
		{
			var configuration = Db4objects.Db4o.Db4oFactory.NewConfiguration();
			return configuration;
		}

		#endregion
	}
}
