using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IAuthorRepository : IRepository<IAuthor>
    {
        /// <summary>
        /// For login action
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IAuthor GetByCredential(string username, string password);
        /// <summary>
        /// To check if the username in use.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IAuthor GetByUsername(string username);
        /// <summary>
        /// To check if the e-mail address in use.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IAuthor GetByEmail(string email);
        /// <summary>
        /// Get the Author of the Post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IAuthor GetByPost(int postId);
        /// <summary>
        /// Get the Founder Author of the Blog.
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        IAuthor GetByFoundedBlog(int blogId);
        IQueryable<IAuthor> Get();
        IQueryable<IAuthor> Get(int skip, int take);
        IQueryable<IAuthor> Get(int blogId, int skip, int take);
    }
}
