using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Event.PostEvents;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Services.Post
{
	public class PostService:IPostService
	{
		#region IPostService Members

		public void AddPost(IPost post)
		{
			PostAddingEvent postAdding=new PostAddingEvent(this,post);
			if (postAdding.Cancel)
				return;
			Repository<IPost>.Instance.Add(post);
			PostAddedEvent postAdded = new PostAddedEvent(this, post);
		}

		public void AddComment(IPostComment comment)
		{
			CommentAddingEvent commentAdding = new CommentAddingEvent(this,comment);
			if (commentAdding.Cancel)
				return;
			Repository<IPostComment>.Instance.Add(comment);
			CommentAddedEvent commentAdded = new CommentAddedEvent(this, comment);
		}

		public void RemoveComment(IPostComment comment)
		{
			Repository<IPostComment>.Instance.Remove(comment);
		}

		public void RemovePost(IPost post)
		{
			PostRemovingEvent postRemoving=new PostRemovingEvent(this,post);
			if (postRemoving.Cancel)
				return;
			Repository<IPost>.Instance.Remove(post);
			PostRemovedEvent postRemoved = new PostRemovedEvent(this, post);
		}

		public IPost GetPostById(int id)
		{
			return Repository<IPost>.Instance.GetById(id);
		}

		public IPost GetPostByFriendlyTitle(string friendlyTitle)
		{
			return Repository<IPost>.Instance.GetByExpression(x => x.FriendlyTitle == friendlyTitle).FirstOrDefault();
		}

		#endregion
	}
}