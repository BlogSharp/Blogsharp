using System;

namespace BlogSharp.Model
{
	public interface ITag : IIdentifiable<Guid>
	{
		string Name { get; set; }
	}
}