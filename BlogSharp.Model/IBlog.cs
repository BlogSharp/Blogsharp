using System.Collections.Generic;

namespace BlogSharp.Model
{
	public interface IBlog : IIdentifiable<int>, IEntity
	{
		string Name { get; set; }
		IAuthor Founder { get; set; }
		IList<IAuthor> Authors { get; set; }
		IList<IPost> Posts { get; set; }
	}
}
