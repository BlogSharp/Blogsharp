namespace BlogSharp.Core.Services.Encryption
{
	using System.IO;

	public interface IEncryptor
	{
		byte[] EncryptString(string s);
		byte[] EncryptStream(Stream s);
		void EncryptStream(Stream i, Stream o);

		string DecryptString(byte[] s);
		byte[] DecryptStream(Stream s);
		void DecryptStream(Stream i, Stream o);
	}
}