namespace BlogSharp.Core.Event.ApplicationEvents
{
	public class ApplicationStarted : AbstractEvent<IApplication>
	{
		public ApplicationStarted(IApplication app)
			: base(app)
		{
		}
	}
}