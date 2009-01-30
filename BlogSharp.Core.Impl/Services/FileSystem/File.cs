using System.IO;
using BlogSharp.Core.Impl.Services.FileSystem.Native;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public class File : FileSystemInfoBase, IFile
	{
		private readonly NativeMethods.WIN32_FIND_DATA findData;

		internal File(string fileName, NativeMethods.WIN32_FIND_DATA fileData)
			: base(fileName)
		{
			findData = fileData;
		}

		#region IFile Members

		public long Length
		{
			get { return findData.nFileSizeHigh; }
		}

		public FileAttributes Attributes
		{
			get { return (FileAttributes) findData.dwFileAttributes; }
		}

		#endregion
	}
}