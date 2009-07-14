// <copyright file="IEntity.cs" company="BlogSharp">
// Coypyleft 2009 Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

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