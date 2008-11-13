using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Services.Compression
{
	public interface IArchiveItem
	{
		string Name { get; }
		long Size { get; }
		void ExtractToStream(Stream strm);
	}
}
