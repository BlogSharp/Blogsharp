namespace BlogSharp.Core.Impl.Tests.Helpers
{
	using System;
	using Core.Helpers;
	using NUnit.Framework;

	[TestFixture]
	public class GuardTests
	{
		[Test]
		public void Null_throws_exception_on_null()
		{
			Assert.Throws<ArgumentNullException>(() => Guard.NotNull(null, "Mahmut"));
		}

		[Test]
		public void Null_throws_exception_on_null_expr()
		{
			var parameter = null as string;
			Assert.Throws<ArgumentNullException>(() => Guard.NotNull(()=>parameter));
		}

		[Test]
		public void NullOrEmpty_throws_exception_on_null_or_Empty()
		{
			Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(null, "Mahmut"));
			Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty("", "Mahmut"));
		}

		[Test]
		public void NullOrEmpty_throws_exception_on_null_expr()
		{
			var parameter = null as string;
			Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(() => parameter));
			parameter = "";
			Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(() => parameter));
		}
	}
}
