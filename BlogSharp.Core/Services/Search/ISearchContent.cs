namespace BlogSharp.Core.Services.Search
{
	using System;
	public interface ISearchContent
	{
		string Title { get; set; }
		string Summary { get; set; }
		string Contents { get; set; }
		string SearchContentID { get; set; }
		string ResultTitle { get; set; }
		DateTime Date { get; set; }
		string Url { get; set; }
	}
}
