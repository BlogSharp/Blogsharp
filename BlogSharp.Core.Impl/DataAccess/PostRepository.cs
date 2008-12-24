using System;
using System.Collections.Generic;
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
        public IList<IPost> GetByBlog(int blogId)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId).OrderByDescending(x => x.DatePublished).ToList();
        }

        /// <summary>
        /// Get the Post List of the Blog, with paging support.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IList<IPost> GetByBlog(int blogId, int skip, int take)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId).OrderByDescending(x => x.DatePublished).Skip(skip).Take(take).ToList();
        }

        /// <summary>
        /// Get the Post list via selected date on the calander.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="date"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IList<IPost> GetByDate(int blogId, DateTime date, int skip, int take)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId && x.DatePublished == date).Skip(skip).Take(take).ToList();
        }

        /// <summary>
        /// Get the Post list of the User.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="authorId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IList<IPost> GetByAuthor(int blogId, int authorId, int skip, int take)
        {
            return container.Query<IPost>(x => x.Blog.Id == blogId && x.User.Id == authorId).OrderByDescending(x => x.DatePublished).Skip(skip).Take(take).ToList();
        }

        /// <summary>
        /// Get the Post list via Tag.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="tagId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IList<IPost> GetByTag(int blogId, int tagId, int skip, int take)
        {
            // TODO: Blog suzmesine ihtiyac var mi?
            var tag = container.Query<ITag>(x => x.Id == tagId).SingleOrDefault();
            return container.Query<IPost>(x => x.Blog.Id == blogId && x.Tags.Contains(tag)).OrderByDescending(x => x.DatePublished).Skip(skip).Take(take).ToList();
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
