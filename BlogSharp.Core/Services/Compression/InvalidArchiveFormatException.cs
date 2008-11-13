using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Compression
{
	public class InvalidFileFormatException : Exception
	{
		public string FileName { get; set; }
	}
}
