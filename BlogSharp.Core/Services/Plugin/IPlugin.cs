using Castle.MicroKernel;

namespace BlogSharp.Core.Services.Plugin
{
	public interface IPlugin
	{
		IKernel PluginKernel { get; set; }
		void Start();
		void Stop();
		void Install();
		void UnInstall();
	}
}