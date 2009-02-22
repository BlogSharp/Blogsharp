namespace BlogSharp.Core.Services.FileSystem
{
	using System.Collections.Generic;

	public interface IDirectory : IFileSystemInfo
	{
		IEnumerable<IFileSystemInfo> Children { get; }
	}
}