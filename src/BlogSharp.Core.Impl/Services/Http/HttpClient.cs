namespace BlogSharp.Core.Impl.Services.Http
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using Core.Services.Http;

	public class DownloadDataCompletedState
	{
		public DownloadDataCompletedCallback Callback { get; set; }
		public object State { get; set; }
	}
	public class DownloadStringCompletedState
	{
		public DownloadStringCompletedCallback Callback { get; set; }
		public object State { get; set; }
	}
	public class HttpClient:IHttpClient
	{
		public HttpClient()
		{
			this.webClient = new WebClient();
			this.webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
			this.webClient.DownloadDataCompleted += webClient_DownloadDataCompleted;
		}

		void webClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			var state = e.UserState as DownloadDataCompletedState;
			state.Callback(e.Result, state.State);
		}

		void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			var state = e.UserState as DownloadStringCompletedState;
			state.Callback(e.Result, state.State);
		}

		private WebClient webClient;



		public string DownloadString(string url)
		{
			return this.DownloadString(new Uri(url));
		}

		public string DownloadString(Uri uri)
		{
			return this.webClient.DownloadString(uri);
		}

		public void DownloadStringAsync(string url, DownloadStringCompletedCallback callback, object state)
		{
			this.DownloadStringAsync(new Uri(url), callback, state);
		}

		public void DownloadStringAsync(Uri uri, DownloadStringCompletedCallback callback, object state)
		{
			this.webClient.DownloadStringAsync(uri, new DownloadStringCompletedState {Callback = callback, State = state});
		}

		public byte[] DownloadData(string url)
		{
			return webClient.DownloadData(url);
		}

		public byte[] DownloadData(Uri uri)
		{
			return webClient.DownloadData(uri);
		}

		public void DownloadDataAsync(string url, DownloadDataCompletedCallback callback, object state)
		{
			this.DownloadDataAsync(new Uri(url),callback,state);
		}

		public void DownloadDataAsync(Uri uri, DownloadDataCompletedCallback callback, object state)
		{
			this.webClient.DownloadDataAsync(uri, new DownloadDataCompletedState {Callback = callback, State = state});
		}
	}
}
