namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	[TestFixture]
	public class BlogValidationTests : ValidationTestBase<BlogValidator, Blog>
	{
		[Test]
		public void Should_raise_error_when_configuration_is_null()
		{
			ShouldHaveErrors(x => x.Configuration, null);
		}

		[Test]
		public void Should_raise_error_when_founder_is_null()
		{
			ShouldHaveErrors(x => x.Founder, null);
		}

		[Test]
		public void Should_raise_error_when_host_is_null()
		{
			ShouldHaveErrors(x => x.Host, null);
			ShouldHaveErrors(x => x.Host, "");
		}

		[Test]
		public void Should_raise_error_when_name_is_not_specified()
		{
			ShouldHaveErrors(x => x.Name, null);
			ShouldHaveErrors(x => x.Name, "");
		}

		[Test]
		public void Should_raise_error_when_title_is_null()
		{
			ShouldHaveErrors(x => x.Title, null);
			ShouldHaveErrors(x => x.Title, "");
		}
	}
}