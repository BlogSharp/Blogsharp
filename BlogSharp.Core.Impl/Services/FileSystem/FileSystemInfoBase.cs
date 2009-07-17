namespace BlogSharp.Core.Impl.Services.FileSystem
{
	using System;
	using Core.Services.FileSystem;

	public abstract class FileSystemInfoBase : IFileSystemInfo
	{
		protected readonly string fileName;

		protected FileSystemInfoBase(string fileName)
		{
			this.fileName = fileName;
			//this.parent = parent;
		}

		#region IFileSystemInfo Members

		public string Name
		{
			get { return System.IO.Path.GetFileName(Path); }
		}

		public FileSystemType Type
		{
			get { return this is File ? FileSystemType.File : FileSystemType.Directory; }
		}

		public virtual IDirectory Parent
		{
			get { return null; }
		}

		public string Path
		{
			get { return fileName; }
		}

		public string GetRelativePath(string root)
		{
			throw new NotImplementedException();
		}

		#endregion

		public override string ToString()
		{
			return Path;
		}
	}
}