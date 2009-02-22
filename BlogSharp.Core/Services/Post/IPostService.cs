namespace BlogSharp.Core.Services.Post
{
	using System.Collections.Generic;
	using Event.PostEvents;
	using Model;

	public interface IPostService
	{
		void AddPost(Model.Post post);
		void AddComment(PostComment comment);
		void RemoveComment(PostComment comment);
		void RemovePost(Model.Post post);
		Model.Post GetPostById(Blog blog, int id);
		Model.Post GetPostByFriendlyTitle(Blog blog, string friendlyTitle);
		IList<Model.Post> GetPostsByBlog(Blog blog);
		IList<Model.Post> GetPostsByBlogPaged(Blog blog, int skip, int take);
		IList<Model.Post> GetPostsByTagPaged(Blog blog, string friendlyTagName, int skip, int take);

		event EventHandler<PostAddingEventArgs> PostAdding;
		event EventHandler<PostAddedEventArgs> PostAdded;
		event EventHandler<PostRemovingEventArgs> PostRemoving;
		event EventHandler<PostRemovedEventArgs> PostRemoved;

		event EventHandler<CommentAddingEventArgs> CommentAdding;
		event EventHandler<CommentAddedEventArgs> CommentAdded;
	}
}