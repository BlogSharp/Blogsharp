using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogSharp.Model
{
	public class Post : IEntity
	{
		public Post()
		{
			Comments = new List<PostComment>();
			Tags = new List<Tag>();
		}

		[Required]
		public Blog Blog { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public DateTime DateCreated { get; set; }

		[Required]
		public DateTime DatePublished { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string FriendlyTitle { get; set; }

		[Required]
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