using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface ITagRepository : IRepository<ITag>
    {
        /// <summary>
        /// Get the Tag list of the Blog.
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        IQueryable<ITag> GetByBlog(int blogId);
        /// <summary>
        /// Get the Tag list of the Blog, with paging support.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<ITag> GetByBlog(int blogId, int skip, int take);
        /// <summary>
        /// Get the Tag list of the Post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IQueryable<ITag> GetByPost(int postId);
    }
}
