namespace BlogSharp.Core.Services.Search
{
	using Model.Interfaces;

	/// <summary>
	/// Common interface for all the search Transformers.
	/// </summary>
	/// <typeparam name="TOriginal">The Type of the Item.</typeparam>
	public interface ISearchContentTransformer<TOriginal>
	{
		/// <summary>
		/// Convert from TOriginal to ISearchContent.
		/// </summary>
		/// <param name="item">The item to transform.</param>
		/// <returns>The transformed item.</returns>
		ISearchContent ConvertToSearchContent(TOriginal item);
	}
}