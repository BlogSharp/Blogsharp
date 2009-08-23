namespace BlogSharp.NHibernate.Tests.MappingTests
{
	using System;
	using FluentNHibernate.Cfg;
	using FluentNHibernate.Cfg.Db;
	using global::NHibernate;
	using global::NHibernate.Cfg;
	using global::NHibernate.Tool.hbm2ddl;
	using Mappings;
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
			cfg=Fluently.Configure()
				.Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<UserMap>())
				.Database(MsSqlConfiguration.MsSql2008
							.AdoNetBatchSize(20)
							.ConnectionString(stringBuilder=>
							                  		stringBuilder.Database("test")
							                  			.TrustedConnection()
							                  			.Server("."))
							.ShowSql()
							.Raw("hbm2ddl.keywords", "auto-quote")
				).BuildConfiguration();
			
			factory = cfg.BuildSessionFactory();
			var export = new SchemaExport(cfg);
			export.Execute(true, true, false);
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