namespace BlogSharp.Core.Services.Plugin
{
	using Castle.MicroKernel;

	public interface IPlugin
	{
		void Start();
		void Stop();
		void Install();
		void UnInstall();
	}
}