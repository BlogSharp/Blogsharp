using System.Collections.Generic;
using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Model;
using System;
namespace BlogSharp.Core.Services.Post
{
	public interface IPostService
	{
		void AddPost(Model.Post post);
		void AddComment(PostComment comment);
		void RemoveComment(PostComment comment);
		void RemovePost(Model.Post post);
		Model.Post GetPostById(int id);
		Model.Post GetPostByFriendlyTitle(string friendlyTitle);
		IList<Model.Post> GetPostsByBlog(Blog blog);
		IList<Model.Post> GetPostsByBlogPaged(Blog blog, int skip, int take);

		event EventHandler<PostAddingEventArgs> PostAdding;
		event EventHandler<PostAddedEventArgs> PostAdded;
		event EventHandler<PostRemovingEventArgs> PostRemoving;
		event EventHandler<PostRemovedEventArgs> PostRemoved;

		event EventHandler<CommentAddingEventArgs> CommentAdding;
		event EventHandler<CommentAddedEventArgs> CommentAdded;
	}
}