using System;

namespace BlogSharp.Core.Impl.Plugins.Pingback
{
	using Event.PostEvents;

	public interface IPingbackService
	{
		void HandleNewPost(PostAddedEventArgs post);

		void SendPingback(string pingbackUri, string sourceUri, string targetUri);
		void SendPingback(Uri pingbackUri, Uri sourceUri, Uri targetUri);

		void ProcessPingback(string sourceUri, string targetUri);
		void ProcessPingback(Uri sourceUri, Uri targetUri);
	}
}
