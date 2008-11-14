using System;

namespace BlogSharp.Core.Services.Compression
{
	public class InvalidFileFormatException : Exception
	{
		public string FileName { get; set; }
	}
}