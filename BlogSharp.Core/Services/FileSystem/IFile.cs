namespace BlogSharp.Core.Services.FileSystem
{
	using System.IO;

	public interface IFile : IFileSystemInfo
	{
		long Length { get; }
		FileAttributes Attributes { get; }
	}
}