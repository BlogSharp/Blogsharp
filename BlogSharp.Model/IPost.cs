using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface IPost:IIdentifiable<int>
	{
		IBlog Blog { get; set; }
		IAuthor Author { get; set; }

		DateTime DateCreated { get; set; }
		DateTime DatePublished { get; set; }

		string Title { get; set; }
		string FriendlyTitle { get; set; }
		string Content { get; set; }

		IList<ITag> Tags { get; set; }
		IList<IPostComment> Comments { get; set; }
	}
}
