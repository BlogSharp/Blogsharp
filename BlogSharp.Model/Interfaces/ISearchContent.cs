namespace BlogSharp.Model.Interfaces
{
	using System;

	/// <summary>
	/// Represent an interface for all the searchable content.
	/// </summary>
	public interface ISearchContent
	{
		/// <summary>
		/// Gets or sets Title.
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets Summary.
		/// </summary>
		string Summary { get; set; }

		/// <summary>
		/// Gets or sets Contents.
		/// </summary>
		string Contents { get; set; }

		/// <summary>
		/// Gets or sets SearchContentID.
		/// </summary>
		string SearchContentID { get; set; }

		/// <summary>
		/// Gets or sets ResultTitle.
		/// </summary>
		string ResultTitle { get; set; }

		/// <summary>
		/// Gets or sets Date.
		/// </summary>
		DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets Url.
		/// </summary>
		string Url { get; set; }
	}
}