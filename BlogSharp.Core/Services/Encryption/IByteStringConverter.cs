using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Encryption
{
	public interface IByteStringConverter
	{
		string ConvertByteToString(byte[] b);
		byte[] ConvertStringToByte(string s);
	}
}
