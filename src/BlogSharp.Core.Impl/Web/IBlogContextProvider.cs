namespace BlogSharp.Core.Impl.Web
{
	public abstract class BlogContextProvider
	{
		public static BlogContextProvider Current { get; set; }
		public abstract BlogContext GetCurrentBlogContext();
	}
}