using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IDirectory:IFileSystemInfo
	{
		IEnumerable<IFileSystemInfo> Children{ get; }
	}
}
