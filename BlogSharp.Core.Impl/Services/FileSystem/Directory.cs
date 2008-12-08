using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.FileSystem;

namespace BlogSharp.Core.Impl.Services.FileSystem
{
	public class Directory:FileSystemInfoBase,IDirectory
	{
		public Directory(DirectoryInfo di):base(di)
		{
			
		}

		#region IDirectory Members

		public IEnumerable<IFileSystemInfo> GetChildren()
		{
			var infos = this.DirectoryInfo.GetFileSystemInfos();
			foreach (var info in infos)
			{
				if (info is FileInfo)
					yield return new File(info as FileInfo);
				else if (info is DirectoryInfo)
					yield return new Directory(info as DirectoryInfo);
			}
		}

		public IFile CreateFile(string name)
		{
			var fileInfo=new FileInfo(System.IO.Path.Combine(this.Path, name));
			fileInfo.Create().Dispose();//bah!
			return new File(fileInfo);
		}

		public IDirectory CreateDirectory(string name)
		{
			var dirInfo = new DirectoryInfo(System.IO.Path.Combine(this.Path, name));
			dirInfo.Create();
			return new Directory(dirInfo);
		}

		#endregion
		private DirectoryInfo DirectoryInfo
		{
			get { return this.FileSystemInfo as DirectoryInfo; }
		}
		public override IDirectory Parent
		{
			get { return new Directory(this.DirectoryInfo.Parent); }
		}
	}
}
