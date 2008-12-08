using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public class File:FileSystemInfoBase,IFile
	{
		public File(FileInfo fileInfo):base(fileInfo)
		{
			
		}

		#region IFile Members
		private FileInfo FileInfo
		{
			get
			{
				return this.FileSystemInfo as FileInfo;
			}
		}
		public Stream OpenRead()
		{
			return FileInfo.OpenRead();
		}

		public Stream OpenWrite()
		{
			return FileInfo.OpenWrite();
		}

		public long Length
		{
			get { return FileInfo.Length; }
		}

		public FileAttributes Attributes
		{
			get { return FileInfo.Attributes; }
		}
		#endregion

		public override IDirectory Parent
		{
			get { return new Directory(FileInfo.Directory); }
		}
	}
}
