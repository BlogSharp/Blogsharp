using Castle.Core.Configuration;

namespace BlogSharp.Db4o
{
	public interface IObjectServerConfigurationBuilder
	{
		/// <summary>
		/// Builds the Configuration object from the specifed configuration
		/// </summary>
		Db4objects.Db4o.Config.IConfiguration GetConfiguration(IConfiguration config);
	}
}