namespace BlogSharp.Core.Services.Encryption
{
	using System.IO;

	public interface IEncryptionService
	{
		byte[] HashFileReturnByteArray(string filename);
		string HashFileReturnString(string filename);

		string HashStringReturnString(string file);
		byte[] HashStringReturnByte(string file);


		byte[] EncrpytFile(string filename);
		void EncryptFile(string filename, string outputfilename);
		void EncryptStream(Stream input, Stream output);

		byte[] DecryptFile(string filename);
		void DecryptFile(string infilename, string outfilename);
		void DecryptStream(Stream input, Stream output);
	}
}