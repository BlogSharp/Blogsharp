using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IPostCommentRepository : IRepository<IPostComment>
    {
        /// <summary>
        /// Get the Comment list of the Post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<IPostComment> GetByPost(int postId, int skip, int take);
    }
}
