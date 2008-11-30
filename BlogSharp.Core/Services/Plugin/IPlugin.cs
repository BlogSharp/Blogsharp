using Castle.MicroKernel;

namespace BlogSharp.Core.Services.Plugin
{
	public interface IPlugin
	{
		void Start();
		void Stop();
		void Install();
		void UnInstall();
		IKernel PluginKernel { get; set; }
	}
}
