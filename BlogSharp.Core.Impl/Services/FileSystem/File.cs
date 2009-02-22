namespace BlogSharp.Core.Impl.Services.FileSystem
{
	using System.IO;
	using Core.Services.FileSystem;
	using Native;

	public class File : FileSystemInfoBase, IFile
	{
		private readonly NativeMethods.WIN32_FIND_DATA findData;

		internal File(string fileName, NativeMethods.WIN32_FIND_DATA fileData)
			: base(fileName)
		{
			this.findData = fileData;
		}

		#region IFile Members

		public long Length
		{
			get { return this.findData.nFileSizeHigh; }
		}

		public FileAttributes Attributes
		{
			get { return (FileAttributes) this.findData.dwFileAttributes; }
		}

		#endregion
	}
}