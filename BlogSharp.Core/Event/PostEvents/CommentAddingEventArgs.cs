﻿using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddingEventArgs : AbstractEventArgs<IPostService>, ICancellableEvent
	{
		public CommentAddingEventArgs(IPostService postService, PostComment comment)
			: base(postService)
		{
			Comment = comment;
		}

		public PostComment Comment { get; private set; }

		#region ICancellableEvent Members

		public bool Cancel { get; set; }

		#endregion
	}
}