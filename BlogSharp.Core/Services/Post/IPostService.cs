using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Model;
using System;
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

		event EventHandler<PostAddingEventArgs> PostAdding;
		event EventHandler<PostAddedEventArgs> PostAdded;
		event EventHandler<PostRemovingEventArgs> PostRemoving;
		event EventHandler<PostRemovedEventArgs> PostRemoved;

		event EventHandler<CommentAddingEventArgs> CommentAdding;
		event EventHandler<CommentAddedEventArgs> CommentAdded;
	}
}