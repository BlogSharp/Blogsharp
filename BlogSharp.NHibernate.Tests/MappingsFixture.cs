
namespace BlogSharp.NHibernate.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using global::NHibernate.Cfg;
	using NUnit.Framework;
	using global::NHibernate.Tool.hbm2ddl;
	using global::NHibernate;
	using BlogSharp.Model;

	[TestFixture]
	public class MappingsFixture
	{
		private Configuration cfg;
		private ISessionFactory factory;

		[TestFixtureSetUp]
		public void SetUp()
		{
			this.cfg = new Configuration();
			this.cfg.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
			this.cfg.Properties["connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
			this.cfg.Properties["connection.connection_string"] = "Data Source=.;Initial Catalog=test;Integrated Security=SSPI";
			this.cfg.Properties["dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
			this.cfg.Properties["proxyfactory.factory_class"] = "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";
			this.cfg.Properties["show_sql"] = "true";
			this.cfg.AddAssembly("BlogSharp.NHibernate");
			this.factory = cfg.BuildSessionFactory();
			SchemaExport export = new SchemaExport(this.cfg);
			export.Execute(true, true, false, true);
		}

		[Test]
		public void Can_save_all_entities()
		{
			using(var session=factory.OpenSession())
			using(var tran=session.BeginTransaction())
			{
				var blog = new Blog();
				var user = new User();
				var post = new Post();
				var configuration = new BlogConfiguration();
				configuration.PageSize = 3;
				configuration["osman"] = "mahmut";
				blog.Configuration = configuration;
				blog.Writers.Add(user);
				blog.Title = "my blog";
				blog.Name = "My Blog";
				blog.Founder = user;
				post.Blog = blog;
				post.Content = "hello";
				post.User = user;
				user.Posts.Add(post);
				session.Save(post);
				session.Save(blog);
				session.Save(user);
				tran.Commit();
			}
			using(var session=factory.OpenSession())
			{
				var item = session.CreateCriteria<Blog>().UniqueResult<Blog>();
				var pageSize = item.Configuration.PageSize;
				Assert.That(pageSize,Is.EqualTo(3));
			}
		}
	}
}
