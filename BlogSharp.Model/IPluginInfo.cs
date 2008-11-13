using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model
{
	public interface IPluginInfo:IIdentifiable<int>
	{
		string Guid { get; set; }
		string Description { get; set; }
		string FriendlyName { get; set; }
		string Name { get; set; }
		string Version { get; set; }
		string Type { get; set; }
		string FolderName { get; set; }
		string AssemblyFolder { get; set; }
	}
}
