namespace BlogSharp.Core.Services.Plugin
{
	public interface IPlugin
	{
		void Start();
		void Stop();
		void Install();
		void UnInstall();
	}
}