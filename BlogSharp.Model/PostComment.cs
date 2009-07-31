namespace BlogSharp.Model
{
	using System.Collections.Generic;

	public class PostComment:Comment
	{
		public virtual Post Parent{ get; set;}
		public virtual IEnumerable<CommentComment> SubComments{ get; set;}
	}

	public class CommentComment:Comment
	{
		public virtual PostComment Parent { get; set; }
		public virtual IEnumerable<PostComment> SubComments { get; set; }
	}
}
