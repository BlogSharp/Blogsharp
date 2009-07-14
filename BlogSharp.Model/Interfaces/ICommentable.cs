// <copyright file="ICommentable.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-22</date>

namespace BlogSharp.Model.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Base Interface for all the commentable Items.
    /// </summary>
    public interface ICommentable : IEntity
    {
        /// <summary>
        /// Gets or sets Comments.
        /// </summary>
        IList<ICommentable> Comments { get; set; }

        /// <summary>
        /// Adds a Comment to a Post.
        /// </summary>
        /// <param name="comment">The Comment to add.</param>
        /// <param name="commented">The commented entity.</param>
        void AddComment(ICommentable comment, ICommentable commented);
    }
}
