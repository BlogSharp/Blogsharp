namespace BlogSharp.Core.Services.Compression
{
	using System;

	public class InvalidFileFormatException : Exception
	{
		public string FileName { get; set; }
	}
}