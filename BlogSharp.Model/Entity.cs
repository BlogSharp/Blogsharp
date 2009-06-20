// <copyright file="Entity.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model
{
	using System;
	using Interfaces;

	/// <summary>
	/// Represennts all the entitys.
	/// </summary>
	[Serializable]
	public abstract class Entity : IEntity
	{
		#region IEntity Members

		/// <summary>
		/// Gets or sets ID.
		/// </summary>
		public virtual long ID { get; set; }

		#endregion
	}
}