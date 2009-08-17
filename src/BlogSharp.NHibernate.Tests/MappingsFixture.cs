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
			cfg = new Configuration();
			cfg.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
			cfg.Properties["connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
			cfg.Properties["connection.connection_string"] =
				"Data Source=.\\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI";
			cfg.Properties["dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
			cfg.Properties["proxyfactory.factory_class"] =
				"NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";
			cfg.Properties["show_sql"] = "true";
			cfg.AddAssembly("BlogSharp.NHibernate");
			factory = cfg.BuildSessionFactory();
			var export = new SchemaExport(cfg);
			export.Execute( true, false, true);
		}
	}
}