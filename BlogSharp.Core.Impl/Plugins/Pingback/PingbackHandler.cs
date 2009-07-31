namespace BlogSharp.Core.Impl.Plugins.Pingback
{
	using System;
	using CookComputing.XmlRpc;
	using Core.Services.Post;

	public class PingbackHandler:XmlRpcService,IPingback
	{
		private readonly IPingbackService pingbackService;

		public PingbackHandler(IPingbackService pingbackService)
		{
			this.pingbackService = pingbackService;
		}

		public string Ping(string sourceUri, string targetUri)
		{
			try
			{
				this.pingbackService.ProcessPingback(sourceUri, targetUri);
				return "Thank you";
			}
			catch (Exception)
			{
				return "Error";
				throw;
			}
			
		}
	}
}