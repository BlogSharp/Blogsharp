namespace BlogSharp.Core.Persistence
{
	using Model;

	public interface IDataInitializer
	{
		bool ShouldRun(Blog blog);
		void Run(Blog blog);
	}
}