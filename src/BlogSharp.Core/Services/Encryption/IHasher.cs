namespace BlogSharp.Core.Services.Encryption
{
	using System.IO;

	public interface IHasher
	{
		byte[] HashStream(Stream s);
		byte[] HashBytes(byte[] s);
	}
}