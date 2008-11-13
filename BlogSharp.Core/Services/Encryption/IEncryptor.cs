using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Encryption
{
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
