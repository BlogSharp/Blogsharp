// <copyright file="IIndexContributor.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Core.Services.Search
{
    using Model.Interfaces;

    /// <summary>
    /// Represents an Interface for the Index Contributor.
    /// </summary>
    public interface IIndexContributor
	{
        /// <summary>
        /// Searchas for a phrase.
        /// </summary>
        /// <param name="phrase">Phrase to search.</param>
        /// <returns>The Search Content.</returns>
        ISearchContent Search(string phrase);
    }
}