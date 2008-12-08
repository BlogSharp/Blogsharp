using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IFileService
	{
		bool FileExists(string file);
		bool DirectoryExists(string file);
		IFile GetFile(string file);
		IDirectory GetDirectory(string directory);
	}
}
