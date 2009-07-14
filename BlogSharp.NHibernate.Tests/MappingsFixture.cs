// <copyright file="MappingsFixture.cs" company="BlogSharp">
// Coypyleft 2009 Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-06-20</date>

namespace BlogSharp.NHibernate.Tests
{
    using System;
    using global::NHibernate;
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;
    using Model;
    using Model.Validation;
    using NUnit.Framework;

    /// <summary>
    /// This class test all the mappings.
    /// </summary>
    [TestFixture]
    public class MappingsFixture
    {
        /// <summary>
        /// The configuration common to all tests.
        /// </summary>
        private Configuration cfg;

        /// <summary>
        /// The session Factory.
        /// </summary>
        private ISessionFactory factory;

        /// <summary>
        /// Sets Up the testing environment.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.cfg = new Configuration();
            this.cfg.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
            this.cfg.Properties["connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
            this.cfg.Properties["connection.connection_string"] = "Data Source=.\\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI";
            this.cfg.Properties["dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
            this.cfg.Properties["proxyfactory.factory_class"] = "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";
            this.cfg.Properties["show_sql"] = "true";
            this.cfg.AddAssembly("BlogSharp.NHibernate");
            this.factory = this.cfg.BuildSessionFactory();
            var export = new SchemaExport(this.cfg);
            export.Execute(true, true, false, true);
        }

        /// <summary>
        /// This test attempts to save all the entities on our model.
        /// </summary>
        [Test]
        public void CanSaveAllEntities()
        {
            using (var session = this.factory.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var blog = new Blog();
                    var user = new User();
                    var post = new Post();
                    var tag = new Tag();
                    var postComment = new PostComment();

                    var configuration = new BlogConfiguration();
                    configuration.PageSize = 3;
                    configuration["osman"] = "mahmut";

                    user.UserName = "DefaultUser";
                    user.Password = "DefaultPass";
                    user.Email = "default@mail.com";
                    user.Blogs.Add(blog);

                    blog.Configuration = configuration;
                    blog.Writers.Add(user);
                    blog.Title = "my blog";
                    blog.Name = "My Blog";
                    blog.Founder = user;
                    blog.Posts.Add(post);
                    blog.Host = "localhost";

                    post.Blog = blog;
                    post.Content = "hello";
                    post.Publisher = user;
                    post.DateCreated = DateTime.Now;
                    post.DatePublished = DateTime.Now.AddMinutes(3);
                    post.Title = "post title";
                    post.FriendlyTitle = post.Title.Replace(' ', '_').ToLower();
                    post.AddComment(postComment, null);

                    postComment.Post = post;
                    postComment.Date = DateTime.Now.AddMinutes(6);
                    postComment.Email = "someone@blogsharp.com";
                    postComment.Name = "Some One";
                    postComment.Comment = "Some One wrote here!!";

                    tag.Name = "Tag";
                    tag.FriendlyName = "Tagged";
                    tag.Posts.Add(post);
                    post.Tags.Add(tag);

                    var blogVal = new BlogValidator();
                    blogVal.ValidateAndThrowException(blog);

                    var postVal = new PostValidator();
                    postVal.ValidateAndThrowException(post);

                    var postCommVal = new PostCommentValidator();
                    postCommVal.ValidateAndThrowException(postComment);

                    var userVal = new UserValidator();
                    userVal.ValidateAndThrowException(user);

                    var tagVal = new TagValidator();
                    tagVal.ValidateAndThrowException(tag);

                    session.Save(user);
                    session.Save(blog);
                    session.Save(post);
                    session.Save(postComment);
                    session.Save(tag);

                    tran.Commit();
                }
            }

            using (var session = this.factory.OpenSession())
            {
                var item = session.CreateCriteria(typeof(Blog)).UniqueResult<Blog>();
                var pageSize = item.Configuration.PageSize;
                Assert.That(pageSize, Is.EqualTo(3));
            }
        }
    }
}
