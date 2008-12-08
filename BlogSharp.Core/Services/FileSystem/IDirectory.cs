using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IDirectory:IFileSystemInfo
	{
		IEnumerable<IFileSystemInfo> GetChildren();
		IFile CreateFile(string name);
		IDirectory CreateDirectory(string name);
	}
}
