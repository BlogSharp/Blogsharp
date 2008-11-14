namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddedEvent : AbstractEvent<string>
	{
		public CommentAddedEvent() : base(null)
		{
		}
	}
}