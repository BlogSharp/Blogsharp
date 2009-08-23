namespace BlogSharp.Model
{
	using System.Collections.Generic;

	public class PostComment:Comment
	{
		private IList<CommentComment> comments;

		public PostComment()
		{
			this.comments = new List<CommentComment>();
		}
		public virtual Post Parent{ get; set;}
		public virtual IEnumerable<CommentComment> Comments
		{
			get{ return comments;}
		}
	}

	public class CommentComment:Comment
	{
		public CommentComment()
		{
			this.comments = new List<CommentComment>();
		}
		private IList<CommentComment> comments;
		public virtual PostComment Parent { get; set; }
		public virtual IEnumerable<CommentComment> Comments
		{
			get{ return comments;}
		}
	}
}
