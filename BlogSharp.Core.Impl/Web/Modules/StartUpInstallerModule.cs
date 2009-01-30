using System;
using System.Web;
using BlogSharp.Core.Impl.Installers;
using BlogSharp.Core.Web.Modules;

namespace BlogSharp.Core.Impl.Web.Modules
{
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