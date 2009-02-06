using System;
using System.ComponentModel.DataAnnotations;
using BlogSharp.Model.Annotations;

namespace BlogSharp.Model
{
	[Serializable]
	public class PostComment : IEntity
	{
		[Required]
		public Post Post { get; set; }

		[Required]
		public string Comment { get; set; }
		[Required,Email]
		public string Email { get; set; }

		[Required]
		public string Name { get; set; }

		public string Web { get; set; }

		[Required]
		public DateTime Date { get; set; }
		public int Id { get; set; }
	}
}