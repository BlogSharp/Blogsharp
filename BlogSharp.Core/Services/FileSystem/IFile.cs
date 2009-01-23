using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IFile:IFileSystemInfo
	{ 
		long Length { get; }
		FileAttributes Attributes { get; }
	}
}
