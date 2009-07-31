namespace BlogSharp.Core.Impl.Plugins.Pingback
{
	using CookComputing.XmlRpc;
	public interface IPingback
	{
		[XmlRpcMethod("pingback.ping", Description = "Pings a blog")]
		string Ping(string sourceUri, string targetUri);
	}
	public interface IPingbackProxy:IPingback,IXmlRpcProxy
	{
	}
}
