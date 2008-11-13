using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Compression
{
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
