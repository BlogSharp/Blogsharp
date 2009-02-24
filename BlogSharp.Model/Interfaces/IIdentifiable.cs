// <copyright file="IIdentifiable.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model.Interfaces
{
	using System;

	/// <summary>
	/// Represents an Identificable entity.
	/// </summary>
	/// <typeparam name="T">Type of the ID.</typeparam>
	[Obsolete("Do not use this class. Use The abstract Entity instead.")]
	public interface IIdentifiable<T>
	{
		/// <summary>
		/// Gets or sets ID.
		/// </summary>
		T ID { get; set; }
	}
}