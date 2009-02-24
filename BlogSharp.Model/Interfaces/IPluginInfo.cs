// <copyright file="IPluginInfo.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model.Interfaces
{
	/// <summary>
	/// Represents a PlugIn Info.
	/// </summary>
	public interface IPluginInfo : IEntity
	{
		/// <summary>
		/// Gets or sets Guid.
		/// </summary>
		string Guid { get; set; }

		/// <summary>
		/// Gets or sets Description.
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// Gets or sets FriendlyName.
		/// </summary>
		string FriendlyName { get; set; }

		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets Version.
		/// </summary>
		string Version { get; set; }

		/// <summary>
		/// Gets or sets Type.
		/// </summary>
		string Type { get; set; }

		/// <summary>
		/// Gets or sets FolderName.
		/// </summary>
		string FolderName { get; set; }

		/// <summary>
		/// Gets or sets AssemblyFolder.
		/// </summary>
		string AssemblyFolder { get; set; }
	}
}