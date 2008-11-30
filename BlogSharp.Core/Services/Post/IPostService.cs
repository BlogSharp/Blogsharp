using BlogSharp.Model;

namespace BlogSharp.Core.Services.Post
{
	public interface IPostService
	{
		void AddPost(IPost post);
		void AddComment(IPostComment comment);
		void RemoveComment(IPostComment comment);
		void RemovePost(IPost post);
		IPost GetPostById(int id);
		IPost GetPostByFriendlyTitle(string friendlyTitle);

	}
}
