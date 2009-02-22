// <copyright file="Tag.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Tag into the Blog.
    /// </summary>
    [Serializable]
    public class Tag : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag" /> class. 
        /// </summary>
        public Tag()
        {
            this.Posts = new List<Post>();
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets FriendlyName.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Blog.
        /// </summary>
        public Blog Blog { get; set; }

        /// <summary>
        /// Gets or sets Posts.
        /// </summary>
        public IList<Post> Posts { get; set; }
    }
}
