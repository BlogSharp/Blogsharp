using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;
using Microsoft.Win32.SafeHandles;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public class Directory:FileSystemInfoBase,IDirectory
	{
		public Directory(string fileName)
			: base(fileName)
		{
		
		}
		private readonly IDirectory parent;

		#region IDirectory Members
		public virtual IEnumerable<IFileSystemInfo> Children
		{
			get; protected set;
		}

		#endregion

	}
}
