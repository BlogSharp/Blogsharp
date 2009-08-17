namespace BlogSharp.Model.Interfaces
{
	/// <summary>
	/// Base Interface for all the entities.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		/// Gets or sets ID.
		/// </summary>
		long ID { get; set; }

		/// <summary>
		/// Gets Version.
		/// </summary>
		int Version { get; }
	}
}