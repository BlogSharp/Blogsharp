using System.IO;

namespace BlogSharp.Core.Services.Encryption
{
	public interface IHasher
	{
		byte[] HashStream(Stream s);
		byte[] HashBytes(byte[] s);
	}
}