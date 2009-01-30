using BlogSharp.Model;

namespace BlogSharp.Core.Persistence
{
	public interface IDataInitializer
	{
		bool ShouldRun(Blog blog);
		void Run(Blog blog);
	}
}