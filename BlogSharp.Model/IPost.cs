using System;
using System.Collections.Generic;

namespace BlogSharp.Model
{
	public interface IPost : IIdentifiable<Guid>, IEntity
	{
		IBlog Blog { get; set; }
		IUser User { get; set; }

		DateTime DateCreated { get; set; }
		DateTime DatePublished { get; set; }

		string Title { get; set; }
		string FriendlyTitle { get; set; }
		string Content { get; set; }

		IList<ITag> Tags { get; set; }
		IList<IPostComment> Comments { get; set; }
	}
}
