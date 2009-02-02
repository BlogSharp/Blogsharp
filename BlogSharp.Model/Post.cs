using System;
using System.Collections.Generic;

namespace BlogSharp.Model
{
	public class Post : IEntity
	{
		public Post()
		{
			Comments = new List<PostComment>();
			Tags = new List<Tag>();
		}

		public Blog Blog { get; set; }

		public User User { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DatePublished { get; set; }

		public string Title { get; set; }

		public string FriendlyTitle { get; set; }

		public string Content { get; set; }

		public IList<Tag> Tags { get; set; }

		public IList<PostComment> Comments { get; set; }

		public void AddComment(PostComment comment)
		{
			this.Comments.Add(comment);
			comment.Post = this;
		}

		public int Id { get; set; }
	}
}