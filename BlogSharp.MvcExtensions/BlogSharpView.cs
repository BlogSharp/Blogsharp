namespace BlogSharp.MvcExtensions
{
	using Spark.Web.Mvc;

	/// <summary>
	/// Base class for typed blogsharp view files
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class BlogSharpView<T> : SparkView<T> where T : class
	{
	}

	/// <summary>
	/// Untyped base for blogsharp view files. Inherits members from above.
	/// </summary>
	public abstract class BlogSharpView : BlogSharpView<object>
	{
	}
}