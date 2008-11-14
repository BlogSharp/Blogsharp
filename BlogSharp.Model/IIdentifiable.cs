namespace BlogSharp.Model
{
	public interface IIdentifiable<T>
	{
		T Id { get; set; }
	}
}