namespace BlogSharp.Core.Services.Compression
{
	using System.IO;

	public interface IArchiveItem
	{
		string Name { get; }
		long Size { get; }
		void ExtractToStream(Stream strm);
	}
}