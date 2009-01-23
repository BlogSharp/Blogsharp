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
	public class File:FileSystemInfoBase,IFile
	{
		internal File(string fileName,NativeMethods.WIN32_FIND_DATA fileData)
			: base(fileName)
		{
			this.findData = fileData;
		}

		private readonly NativeMethods.WIN32_FIND_DATA findData;
		#region IFile Members

		public long Length
		{
			get { return findData.nFileSizeHigh; }
		}

		public FileAttributes Attributes
		{
			get { return (FileAttributes)findData.dwFileAttributes; }
		}

		#endregion
	}
}
