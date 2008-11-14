namespace BlogSharp.Core
{
	public interface IEntityFactory<T> where T : class
	{
		T Create();
	}
}