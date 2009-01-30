using System.Collections.Generic;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IDirectory : IFileSystemInfo
	{
		IEnumerable<IFileSystemInfo> Children { get; }
	}
}