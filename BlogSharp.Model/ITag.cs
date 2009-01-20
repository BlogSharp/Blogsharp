using System.Collections.Generic;

namespace BlogSharp.Model
{
	public interface ITag : IIdentifiable<int>
	{
		string Name { get; set; }
		IList<IPost> Posts { get; set; }
	}
}