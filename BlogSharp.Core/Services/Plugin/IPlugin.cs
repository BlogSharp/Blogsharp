namespace BlogSharp.Core.Services.Plugin
{
	/// <summary>
	/// The base interface for all the plugins.
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// Starts executing the plugin.
		/// </summary>
		void Start();

		/// <summary>
		/// Stops executing the plugin.
		/// </summary>
		void Stop();

		/// <summary>
		/// Installs the Plugin.
		/// </summary>
		void Install();

		/// <summary>
		/// UniInstalls the plugin.
		/// </summary>
		void UnInstall();
	}
}