namespace BlogSharp.Model.Interfaces
{
	using System;

	/// <summary>
	/// Define the common base for all the postable items.
	/// </summary>
	public interface IPostable : IEntity
	{
		/// <summary>
		/// Gets or sets Blog.
		/// </summary>
		Blog Blog { get; set; }

		/// <summary>
		/// Gets or sets Publisher.
		/// </summary>
		User Publisher { get; set; }

		/// <summary>
		/// Gets or sets DateCreated.
		/// </summary>
		DateTime DateCreated { get; set; }

		/// <summary>
		/// Gets or sets DatePublished.
		/// </summary>
		DateTime DatePublished { get; set; }

		/// <summary>
		/// Gets or sets Content.
		/// </summary>
		string Content { get; set; }
	}
}