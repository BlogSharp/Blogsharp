using BlogSharp.Model;

namespace BlogSharp.Core.Services.Search
{
	public interface IIndexContributor
	{
		ISearchContent Search(string phrase);
	}
}
