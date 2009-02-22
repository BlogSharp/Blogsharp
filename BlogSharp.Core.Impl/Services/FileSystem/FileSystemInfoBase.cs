using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Impl.Services.FileSystem.Native;
using BlogSharp.Core.Services.FileSystem;
using Microsoft.Win32.SafeHandles;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public abstract class FileSystemInfoBase:IFileSystemInfo
	{
		protected FileSystemInfoBase(string fileName)
		{
			this.fileName = fileName;
			//this.parent = parent;
		}

		protected readonly string fileName;
		private readonly IDirectory parent;
		#region IFileSystemInfo Members

		public string Name
		{
			get { return System.IO.Path.GetFileName(this.Path); }
		}

		public FileSystemType Type
		{
			get { return this is File ? FileSystemType.File : FileSystemType.Directory; }
		}

		public virtual IDirectory Parent 
		{
			get{ return this.parent; }
		}

		#endregion


		#region IFileSystemInfo Members


		public string Path
		{
			get { return this.fileName; }
		}

		public string GetRelativePath(string root)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return this.Path;
		}
		#endregion
	}
}
