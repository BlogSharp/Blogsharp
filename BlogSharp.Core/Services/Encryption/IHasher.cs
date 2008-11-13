using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Encryption
{
	public interface IHasher
	{
		byte[] HashStream(Stream s);
		byte[] HashBytes(byte[] s);
	}
}
