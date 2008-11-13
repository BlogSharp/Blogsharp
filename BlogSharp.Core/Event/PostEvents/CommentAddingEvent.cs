using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Event.PostEvents
{
	public class CommentAddingEvent:AbstractEvent<IPostService>,ICancellableEvent
	{
		public CommentAddingEvent(IPostService service,IPostComment comment):base(service)
		{
			this.postComment = comment;
		}

		private readonly IPostComment postComment;

		public IPostComment PostComment
		{
			get { return postComment; }
		}	
		#region ICancellableEvent Members

		public bool Cancel
		{
			get; set;
		}

		#endregion
	}
}
