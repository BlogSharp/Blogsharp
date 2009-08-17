namespace BlogSharp.Core.Services.Compression
{
	using System;
	using System.Collections.Generic;
	using FileSystem;

	public interface IArchiveFile : IDisposable
	{
		string Name { get; }
		IArchiveManager Manager { get; set; }
		IEnumerable<IArchiveItem> Items { get; }
		IArchiveItem this[string item] { get; }
		long Count { get; }
		void Add(IFile fileInfo);
		void Add(IDirectory directoryInfo);
	}
}