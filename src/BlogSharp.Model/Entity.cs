namespace BlogSharp.Model
{
	using System;
	using Interfaces;

	/// <summary>
	/// Represents all the entities.
	/// </summary>
	[Serializable]
	public abstract class Entity : IEntity
	{
		#region IEntity Members

		/// <summary>
		/// Gets or sets ID.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// Gets Version.
		/// </summary>
		public virtual int Version { get; private set; }

		#endregion
	}
}