namespace BlogSharp.Core.Services.Http
{
	using System;
	using System.Net;

	public delegate void DownloadStringCompletedCallback(string str,object state);
	public delegate void DownloadDataCompletedCallback(byte[] data,object state);
	public interface IHttpClient
	{
		string DownloadString(string url);
		string DownloadString(Uri uri);
		void DownloadStringAsync(string url,DownloadStringCompletedCallback callback,object state);
		void DownloadStringAsync(Uri uri, DownloadStringCompletedCallback callback, object state);


		byte[] DownloadData(string url);
		byte[] DownloadData(Uri uri);
		void DownloadDataAsync(string url, DownloadDataCompletedCallback callback, object state);
		void DownloadDataAsync(Uri uri, DownloadDataCompletedCallback callback, object state);


	}
}
