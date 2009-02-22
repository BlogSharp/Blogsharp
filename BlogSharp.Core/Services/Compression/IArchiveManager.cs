namespace BlogSharp.Core.Services.Compression
{
	using System.IO;

	public interface IArchiveManager
	{
		bool CanOpen(string filename);
		bool CanOpen(Stream file);
		IArchiveFile OpenArchive(string filename);
		IArchiveFile OpenArchive(Stream str);
		void Extract(string archiveFile, string destination);
		bool CloseArchive(IArchiveFile archiveFile);
	}
}