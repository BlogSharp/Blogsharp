namespace BlogSharp.Model
{
	public interface ITag : IIdentifiable<int>
	{
		string Name { get; set; }
	}
}