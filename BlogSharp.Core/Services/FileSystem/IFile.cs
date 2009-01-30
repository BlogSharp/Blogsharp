using System.IO;

namespace BlogSharp.Core.Services.FileSystem
{
	public interface IFile : IFileSystemInfo
	{
		long Length { get; }
		FileAttributes Attributes { get; }
	}
}