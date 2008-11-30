using System.Collections.Generic;

namespace BlogSharp.Model
{
	public interface IUserSession : IIdentifiable<int>, IEntity
	{
		string Guid { get; set; }
		IList<string> Ips { get; set; }
	}
}
