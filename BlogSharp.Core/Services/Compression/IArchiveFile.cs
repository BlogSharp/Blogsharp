using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Compression
{
	public interface IArchiveFile : IDisposable
	{
		string Name { get; }
		IArchiveManager Manager { get; set; }
		IEnumerable<IArchiveItem> Items { get; }
		IArchiveItem this[string item] { get; }
		long Count { get; }
		void Add(FileInfo fileInfo);
		void Add(DirectoryInfo directoryInfo);
	}
}
