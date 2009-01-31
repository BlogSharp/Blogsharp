namespace BlogSharp.Model
{
	public class PostComment : IEntity
	{
		public Post Post { get; set; }

		public string Comment { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Web { get; set; }
		public int Id { get; set; }
	}
}