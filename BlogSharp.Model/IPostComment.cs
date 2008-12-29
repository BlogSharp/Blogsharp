using System;

namespace BlogSharp.Model
{
	public interface IPostComment : IIdentifiable<Guid>
	{
		IPost Post { get; set; }
		string Comment { get; set; }
	}
}