using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IAuthorRepository : IRepository<IUser>
    {
        /// <summary>
        /// For login action
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IUser GetByCredential(string username, string password);
        /// <summary>
        /// To check if the username in use.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IUser GetByUsername(string username);
        /// <summary>
        /// To check if the e-mail address in use.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IUser GetByEmail(string email);
        /// <summary>
        /// Get the User of the Post.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IUser GetByPost(int postId);
        /// <summary>
        /// Get the Founder User of the Blog.
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        IUser GetByFoundedBlog(int blogId);
        IQueryable<IUser> Get();
        IQueryable<IUser> Get(int skip, int take);
        IQueryable<IUser> Get(int blogId, int skip, int take);
    }
}
