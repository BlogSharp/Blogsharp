namespace BlogSharp.Core.Impl.Plugins.Pingback
{
	using System;
	using System.Net.Sockets;
	using System.Text.RegularExpressions;
	using CookComputing.XmlRpc;
	using Core.Services.Http;
	using Core.Services.Post;
	using Event.PostEvents;
	using Helpers;
	using Model;
	using System.Linq;

	public class PingbackService:IPingbackService
	{
		private readonly IPostService postService;
		private readonly IHttpClient httpClient;

		public static readonly Regex UriRegEx =
			new Regex(
				@"(?#Protocol)(?:(?:ht|f)tp(?:s?)\:\/\/|~/|/)?(?#Username:Password)(?:\w+:\w+@)?(?#Subdomains)(?:(?:[-\w]+\.)+(?#TopLevel Domains)(?:com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum|travel|[a-z]{2}))(?#Port)(?::[\d]{1,5})?(?#Directories)(?:(?:(?:/(?:[-\w~!$+|.,=]|%[a-f\d]{2})+)+|/)+|\?|#)?(?#Query)(?:(?:\?(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)(?:&(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)*)*(?#Anchor)(?:#(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)?");
		public PingbackService(IPostService postService,IHttpClient httpClient)
		{
			this.postService = postService;
			this.httpClient = httpClient;
		}

		public void HandleNewPost(PostAddedEventArgs eventArgs)
		{
			string[] links = ExtractUrls(eventArgs.Post.Content);
			foreach (var link in links)
			{
				ProcessLink(link);
			}
		}

		protected virtual string[] ExtractUrls(string text)
		{
			return UriRegEx.Matches(text).Cast<Match>().Select(x=>x.Value).ToArray();
		}
		protected virtual void ProcessLink(string link)
		{
			var pingbackUrl = GetPingbackUrl(link);
			SendPingback(pingbackUrl, "hola", link);
		}
		protected virtual string GetPingbackUrl(string link)
		{
			var pageContent = this.httpClient.DownloadString(link);
			if (!string.IsNullOrEmpty(pageContent))
			{
				string pat = "<link rel=\"pingback\" href=\"([^\"]+)\" ?/?>";
				Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
				Match m = reg.Match(pageContent);
				if (m.Success)
				{
					return m.Result("$1");
				}
			}
			return null;
		}

		public virtual void SendPingback(string pingbackUri, string sourceUri, string targetUri)
		{
			Guard.NotNullOrEmpty(() => pingbackUri);
			Guard.NotNullOrEmpty(() => sourceUri);
			Guard.NotNullOrEmpty(() => targetUri);
			var proxy = XmlRpcProxyGen.Create<IPingbackProxy>();
			proxy.Url = pingbackUri;
			proxy.Ping(sourceUri, targetUri);
		}

		public virtual void SendPingback(Uri pingbackUri, Uri sourceUri, Uri targetUri)
		{
			Guard.NotNull(() => pingbackUri);
			Guard.NotNull(() => sourceUri);
			Guard.NotNull(() => targetUri);
			this.SendPingback(pingbackUri.ToString(), sourceUri.ToString(), targetUri.ToString());
		}

		public virtual void ProcessPingback(string sourceUri, string destinationUri)
		{
			Guard.NotNullOrEmpty(() => sourceUri);
			Guard.NotNullOrEmpty(() => destinationUri);

			throw new NotImplementedException();
		}

		public virtual void ProcessPingback(Uri sourceUri, Uri destinationUri)
		{
			Guard.NotNull(() => sourceUri);
			Guard.NotNull(() => destinationUri);
			this.ProcessPingback(sourceUri.ToString(), destinationUri.ToString());
		}
	}
}
