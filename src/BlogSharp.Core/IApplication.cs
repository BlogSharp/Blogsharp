namespace BlogSharp.Core
{
	using Castle.Windsor;

	public interface IApplication
	{
		IWindsorContainer Resolver { get; }
	}
}