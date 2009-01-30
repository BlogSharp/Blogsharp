using System.Collections.Generic;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public class Directory : FileSystemInfoBase, IDirectory
	{
		private readonly IDirectory parent;

		public Directory(string fileName)
			: base(fileName)
		{
		}

		#region IDirectory Members

		public virtual IEnumerable<IFileSystemInfo> Children { get; protected set; }

		#endregion
	}
}