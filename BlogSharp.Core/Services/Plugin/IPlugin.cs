namespace BlogSharp.Core.Services.Plugin
{
	using Castle.MicroKernel;

	public interface IPlugin
	{
		IKernel PluginKernel { get; set; }
		void Start();
		void Stop();
		void Install();
		void UnInstall();
	}
}