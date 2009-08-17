namespace BlogSharp.Core.Impl.Services.FileSystem
{
	using System.Collections.Generic;
	using Core.Services.FileSystem;

	public class Directory : FileSystemInfoBase, IDirectory
	{
		public Directory(string fileName)
			: base(fileName)
		{
		}

		#region IDirectory Members

		public virtual IEnumerable<IFileSystemInfo> Children { get; protected set; }

		#endregion
	}
}