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