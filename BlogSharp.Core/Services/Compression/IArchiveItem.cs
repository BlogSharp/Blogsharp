using System.IO;

namespace BlogSharp.Core.Services.Compression
{
	public interface IArchiveItem
	{
		string Name { get; }
		long Size { get; }
		void ExtractToStream(Stream strm);
	}
}