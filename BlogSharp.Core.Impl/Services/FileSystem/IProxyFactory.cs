using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Impl.Services.FileSystem.Native;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public interface IProxyFactory
	{
		IFile CreateFileWithProxy(IFileService fileService, string fileName, NativeMethods.WIN32_FIND_DATA findData);
		IDirectory CreateDirectoryWithProxy(IFileService fileService, string fileName);
	}
}
