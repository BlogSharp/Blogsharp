using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public class FileService:IFileService
	{
		#region IFileService Members

		public bool FileExists(string file)
		{
			return System.IO.File.Exists(file);
		}

		public bool DirectoryExists(string path)
		{
			return System.IO.Directory.Exists(path);
		}

		public IFile GetFile(string file)
		{
			if(System.IO.File.Exists(file))
			{
				return new File(new System.IO.FileInfo(file));
			}
			else
				throw new FileNotFoundException(file);
		}

		public IDirectory GetDirectory(string directory)
		{
			if (System.IO.Directory.Exists(directory))
			{
				return new Directory(new System.IO.DirectoryInfo(directory));
			}
			else
				throw new FileNotFoundException(directory);
		}

		#endregion
	}
}
