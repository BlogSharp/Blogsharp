using BlogSharp.Model;

namespace BlogSharp.Core.Services.Search
{
	public interface ISearchContentTransformer<TOriginal>
	{
		ISearchContent ConvertToSearchContent(TOriginal item);
	}
}