using System.Collections.Generic;

namespace BlogSharp.Model
{
	public interface IBlog : IIdentifiable<int>, IEntity
	{
		string Name { get; set; }
		IUser Founder { get; set; }
		IList<IUser> Authors { get; set; }
		IList<IPost> Posts { get; set; }
	}
}
