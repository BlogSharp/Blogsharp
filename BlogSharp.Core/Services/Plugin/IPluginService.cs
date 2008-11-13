using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.Services.Plugin
{
	public interface IPluginService
	{
		IList<IPluginInfo> GetActivePlugins();
		IList<IPluginInfo> GetInstalledPlugins();
		IList<IPluginInfo> GetAllPlugins();
		IPluginInfo GetPluginInfo(string guid);

		void ActivatePlugin(IPluginInfo pluginInfo);
		void DeActivatePlugin(IPluginInfo pluginInfo);
		void InstallPlugin(IPluginInfo pluginInfo);
		void UnInstallPlugin(IPluginInfo pluginInfo);


		void ActivatePlugin(string guid);
		void DeActivatePlugin(string guid);
		void InstallPlugin(string guid);
		void UnInstallPlugin(string guid);


		void Start();
		void Stop();
	}
}
