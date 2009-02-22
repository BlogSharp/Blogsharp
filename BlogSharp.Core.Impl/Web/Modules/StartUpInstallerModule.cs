namespace BlogSharp.Core.Impl.Web.Modules
{
	using System;
	using System.Web;
	using Core.Web.Modules;
	using Installers;

	public class StartUpInstallerModule : IBlogSharpHttpModule
	{
		private readonly IStartupInstaller installer;

		public StartUpInstallerModule(IStartupInstaller installer)
		{
			this.installer = installer;
		}

		#region IBlogSharpHttpModule Members

		public void Init(HttpApplication context)
		{
			context.BeginRequest += HandleBeginRequest;
		}

		public void Dispose()
		{
		}

		#endregion

		private void HandleBeginRequest(object sender, EventArgs e)
		{
			installer.Execute();
		}
	}
}