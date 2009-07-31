namespace BlogSharp.Model
{
	public class PluginInfo : Entity
	{
		public virtual string Guid { get; set; }
		public virtual string Description { get; set; }
		public virtual string FriendlyName { get; set; }
		public virtual string Name { get; set; }
		public virtual string Version { get; set; }
		public virtual string Type { get; set; }
		public virtual string FolderName { get; set; }
		public virtual string AssemblyFolder { get; set; }
	}
}