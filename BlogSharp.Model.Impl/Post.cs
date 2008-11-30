using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Impl
{
	public class Post : IPost
	{
		public Post()
		{
			this.Comments=new List<IPostComment>();
			this.Tags=new List<ITag>();
		}
		#region IPost Members

		public IBlog Blog
		{
			get;
			set;
		}

		public IAuthor Author
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

		public IList<ITag> Tags
		{
			get;
			set;
		}

		public IList<IPostComment> Comments
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
