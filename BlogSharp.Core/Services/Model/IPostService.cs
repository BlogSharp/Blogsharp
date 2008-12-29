using System;
using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Model;

namespace BlogSharp.Core.Services.Model
{
	public interface IPostService
	{
		void AddPost(IPost post);
		void AddComment(IPostComment comment);
		void RemoveComment(IPostComment comment);
		void RemovePost(IPost post);
		IPost GetPostById(Guid id);
		IPost GetPostByFriendlyTitle(string friendlyTitle);

		event EventHandler<IPostService, PostAddingEventArgs> PostAdding;
		event EventHandler<IPostService, PostAddedEventArgs> PostAdded;
		event EventHandler<IPostService, PostRemovingEventArgs> PostRemoving;
		event EventHandler<IPostService, PostRemovedEventArgs> PostRemoved;

		event EventHandler<IPostService, CommentAddingEventArgs> CommentAdding;
		event EventHandler<IPostService, CommentAddedEventArgs> CommentAdded;

	}
}