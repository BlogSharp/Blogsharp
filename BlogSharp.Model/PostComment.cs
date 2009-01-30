namespace BlogSharp.Model
{
	public class PostComment : IEntity
	{
		public Post Post { get; set; }

		public string Comment { get; set; }

		public int Id { get; set; }
	}
}