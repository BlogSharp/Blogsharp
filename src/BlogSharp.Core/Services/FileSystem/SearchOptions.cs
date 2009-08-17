namespace BlogSharp.Core.Services.FileSystem
{
	using System;

	[Flags]
	public enum SearchOptions
	{
		File = 0x01,
		Directory = 0x02,
		Both = File | Directory,
	}

	[Flags]
	public enum SearchLocation
	{
		TopDirectory,
		Recursive,
	}
}