namespace BlogSharp.Model
{
	public interface IPostComment : IIdentifiable<int>
	{
		IPost Post { get; set; }
		string Comment { get; set; }
	}
}