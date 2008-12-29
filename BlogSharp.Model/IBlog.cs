using System;
using System.Collections.Generic;

namespace BlogSharp.Model
{
	public interface IBlog : IIdentifiable<Guid>, IEntity
	{
		string Name { get; set; }
		IUser Founder { get; set; }
		IList<IUser> Authors { get; set; }
		IList<IPost> Posts { get; set; }
	}
}
