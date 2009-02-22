// <copyright file="IIdentifiable.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model.Interfaces
{
    /// <summary>
    /// Represents an Identificable entity.
    /// </summary>
    /// <typeparam name="T">Type of the ID.</typeparam>
    public interface IIdentifiable<T>
    {
        //TODO: Check if this is really Needed.
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        T ID { get; set; }
    }
}