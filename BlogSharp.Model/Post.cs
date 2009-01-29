using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public class Post : IEntity
	{
		public Post()
		{
			this.Comments=new List<PostComment>();
			this.Tags=new List<Tag>();
		}
		#region Post Members

		public Blog Blog
		{
			get;
			set;
		}

		public User User
		{
			get;
			set;
		}

		public DateTime DateCreated
		{
			get;
			set;
		}

		public DateTime DatePublished
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string FriendlyTitle
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}

		public IList<Tag> Tags
		{
			get;
			set;
		}

		public IList<PostComment> Comments
		{
			get;
			set;
		}

		#endregion

		#region IIdentifiable<int> Members

		public int Id
		{
			get;
			set;
		}

		#endregion
	}
}
