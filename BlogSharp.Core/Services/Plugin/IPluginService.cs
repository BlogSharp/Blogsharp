namespace BlogSharp.Core.Services.Plugin
{
	using System.Collections.Generic;
	using Model;
	using Model.Interfaces;

	/// <summary>
	/// The common interface for all the plugins.
	/// </summary>
	public interface IPluginService
	{
		/// <summary>
		/// Gets a list of all the Active plugins.
		/// </summary>
		/// <returns>List of al.l the Active plugins.</returns>
		IList<PluginInfo> GetActivePlugins();

		/// <summary>
		/// Gets a list of all the Installed plugins.
		/// </summary>
		/// <returns>List of all the Installed plugins.</returns>
		IList<PluginInfo> GetInstalledPlugins();

		/// <summary>
		/// Gets a list of all the plugins.
		/// </summary>
		/// <returns>List of all the plugins.</returns>
		IList<PluginInfo> GetAllPlugins();

		/// <summary>
		/// Gets the info of a Plugin.
		/// </summary>
		/// <param name="guid">The GUID of the plugin.</param>
		/// <returns>The info of a Plugin.</returns>
		PluginInfo GetPluginInfo(string guid);

		/// <summary>
		/// Activates a Plugin
		/// </summary>
		/// <param name="pluginInfo">The Plugin info</param>
		void ActivatePlugin(PluginInfo pluginInfo);

		/// <summary>
		/// DeActivates a Plugin
		/// </summary>
		/// <param name="pluginInfo">The Plugin info</param>
		void DeActivatePlugin(PluginInfo pluginInfo);

		/// <summary>
		/// Installs a Plugin
		/// </summary>
		/// <param name="pluginInfo">The Plugin info</param>
		void InstallPlugin(PluginInfo pluginInfo);

		/// <summary>
		/// UnInstalls a Plugin
		/// </summary>
		/// <param name="pluginInfo">The Plugin info</param>
		void UnInstallPlugin(PluginInfo pluginInfo);

		/// <summary>
		/// Activates a Plugin
		/// </summary>
		/// <param name="guid">The GUID of the plugin.</param>
		void ActivatePlugin(string guid);

		/// <summary>
		/// DeActivates a Plugin
		/// </summary>
		/// <param name="guid">The GUID of the plugin.</param>
		void DeActivatePlugin(string guid);

		/// <summary>
		/// Installs a Plugin
		/// </summary>
		/// <param name="guid">The GUID of the plugin.</param>
		void InstallPlugin(string guid);

		/// <summary>
		/// UnInstalls a Plugin
		/// </summary>
		/// <param name="guid">The GUID of the plugin.</param>
		void UnInstallPlugin(string guid);

		/// <summary>
		/// Starts a Plugin
		/// </summary>
		void Start();

		/// <summary>
		/// Stops a PlugIn
		/// </summary>
		void Stop();
	}
}