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
		/// Gets or sets PlugInVersion.
		/// </summary>
		string PlugInVersion { get; set; }

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