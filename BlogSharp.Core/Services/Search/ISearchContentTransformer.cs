using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model;

namespace BlogSharp.Core.Services.Search
{
	public interface ISearchContentTransformer<TOriginal>
	{
		ISearchContent ConvertToSearchContent(TOriginal item);
	}
}
