namespace BlogSharp.Core.Event
{
	public interface ICancellableEvent
	{
		bool Cancel { get; set; }
	}
}