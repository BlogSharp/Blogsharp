using System;
using System.Linq;
using BlogSharp.Core.DataAccess;
using BlogSharp.Model;
using Db4objects.Db4o;

namespace BlogSharp.Core.Impl.DataAccess
{
    public class PostRepository : Db4oRepository, IPostRepository
    {
        public PostRepository(IObjectContainer container)
            : base(container)
        {

        }

        #region Implementation of IPostRepository

        /// <summary>
        /// Get the Post list of the Blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public IQueryable<IPost> GetByBlog(int blogId)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId).AsQueryable();
        }

        /// <summary>
        /// Get the Post List of the Blog, with paging support.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<IPost> GetByBlog(int blogId, int skip, int take)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId).Skip(skip).Take(take).AsQueryable();
        }

        /// <summary>
        /// Get the Post list via selected date on the calander.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="date"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<IPost> GetByDate(int blogId, DateTime date, int skip, int take)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId && x.DatePublished == date).Skip(skip).Take(take).AsQueryable();
        }

        /// <summary>
        /// Get the Post list of the User.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="authorId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<IPost> GetByAuthor(int blogId, int authorId, int skip, int take)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId && x.User.Id == authorId).Skip(skip).Take(take).AsQueryable();
        }

        /// <summary>
        /// Get the Post list via Tag.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="tagId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<IPost> GetByTag(int blogId, int tagId, int skip, int take)
        {
            // TODO: Nasil query yapiliyor bu ?
            return container.Query<IPost>(x => x.Blog.Id == blogId).Skip(skip).Take(take).AsQueryable();
        }

        /// <summary>
        /// Saves the post
        /// </summary>
        /// <param name="post"></param>
        public void SavePost(IPost post)
        {
            SaveObject(post);
        }

        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="post"></param>
        public void DeletePost(IPost post)
        {
            RemoveObject(post);
        }

        /// <summary>
        /// Adds the comment
        /// </summary>
        /// <param name="comment"></param>
        public void SaveComment(IPostComment comment)
        {
           SaveObject(comment);
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="comment"></param>
        public void DeleteComment(IPostComment comment)
        {
            RemoveObject(comment);
        }

        /// <summary>
        /// Get the post via SEO friendly title in url-rewrite.
        /// </summary>
        /// <param name="friendlyTitle"></param>
        /// <returns></returns>
        public IPost GetByTitle(string friendlyTitle)
        {
            return container.Query<IPost>(x => x.FriendlyTitle == friendlyTitle).SingleOrDefault();
        }


        public IPost GetPostById(int id)
        {
            return container.Query<IPost>(x => x.Id == id).SingleOrDefault();
        }

        #endregion
    }
}
