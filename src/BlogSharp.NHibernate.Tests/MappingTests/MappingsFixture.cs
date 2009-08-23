namespace BlogSharp.NHibernate.Tests.MappingTests
{
	using System;
	using global::NHibernate;
	using global::NHibernate.Cfg;
	using global::NHibernate.Tool.hbm2ddl;
	using NUnit.Framework;

	/// <summary>
	/// This class test all the mappings.
	/// </summary>
	[TestFixture]
	public abstract class MappingsFixtureBase
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
			cfg = new Configuration();
			cfg.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
			cfg.Properties["connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
			cfg.Properties["connection.connection_string"] =
				"Data Source=.\\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI";
			cfg.Properties["dialect"] = "NHibernate.Dialect.MsSql2005Dialect";
			cfg.Properties["proxyfactory.factory_class"] =
				"NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";
			cfg.Properties["show_sql"] = "true";
			cfg.Properties["hbm2ddl.keywords"] = "auto-quote";
			cfg.AddAssembly("BlogSharp.NHibernate");
			factory = cfg.BuildSessionFactory();
			var export = new SchemaExport(cfg);
			export.Execute( true, true, false);
		}


		[TestFixtureTearDown]
		public void TearDown()
		{
			factory = cfg.BuildSessionFactory();
			var export = new SchemaExport(cfg);
			export.Execute(true, false, true);
		}

		protected virtual void DoInNewSessionAndTransaction(Action<ISession> action)
		{
			using(var session=factory.OpenSession())
			using(var trans=session.BeginTransaction())
			{
				action(session);
				trans.Commit();
			}
		}

		protected virtual ISession OpenSession()
		{
			return factory.OpenSession();
		}
	}
}