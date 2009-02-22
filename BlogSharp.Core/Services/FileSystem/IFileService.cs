namespace BlogSharp.Core.Services.FileSystem
{
	using System.Collections.Generic;
	using System.IO;
	using System.Security.AccessControl;

	public interface IFileService
	{
		bool FileExists(string file);
		bool DirectoryExists(string file);
		void DeleteFile(IFile file);
		void DeleteFile(string file);
		void MoveFile(string source, string destination);
		void MoveFile(IFile source, string destination);
		void CopyFile(string source, string destination);
		void CopyFile(IFile source, string destination);
		Stream OpenFileForRead(string source);
		Stream OpenFileForRead(IFile file);
		Stream OpenFileForWrite(string source);
		Stream OpenFileForWrite(IFile file);
		Stream OpenFile(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare);

		IEnumerable<IFileSystemInfo> SearchDirectory(string directory, string searchPattern, SearchOptions searchOption,
		                                             SearchLocation searchLocation);

		IFile GetFile(string file);

		IFile CreateFile(string file);

		IFile CreateFile(string file, FileMode fileMode, FileAccess fileAccess, FileShare fileShare,
		                 FileSystemRights fileSystemRights, FileOptions fileOptions, FileSecurity fileSecurity);

		IFile CreateFile(string file, FileMode fileMode);
		IFile CreateFile(string file, FileMode fileMode, FileAccess fileAccess);
		IFile CreateFile(string file, FileMode fileMode, FileAccess fileAccess, FileShare fileShare);

		IDirectory GetDirectory(string directory);
	}
}