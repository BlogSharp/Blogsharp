using BlogSharp.Model;

namespace BlogSharp.Core
{
	public interface IEntityFactory<T>
	{
		T Create();
	}
}