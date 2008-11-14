using Castle.Windsor;

namespace BlogSharp.Core
{
	public interface IApplication
	{
		IWindsorContainer Resolver { get; }
	}
}