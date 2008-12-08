using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IFileSystemInfo
	{
		string Name { get; }
		FileSystemType Type { get; }
		IDirectory Parent { get; }
		string Path { get; }
		string GetRelativePath(string root);

	}
}
