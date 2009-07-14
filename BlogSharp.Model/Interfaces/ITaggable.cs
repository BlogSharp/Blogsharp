// <copyright file="ITaggable.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-22</date>

namespace BlogSharp.Model.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Base Interface for all the taggable Items.
    /// </summary>
    public interface ITaggable : IEntity
    {
        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        IList<Tag> Tags { get; set; }
    }
}
