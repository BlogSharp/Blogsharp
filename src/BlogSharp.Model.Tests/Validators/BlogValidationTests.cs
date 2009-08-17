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
			ShouldHaveErrors(new Blog{Configuration=null}, x => x.Configuration);
			ShouldNotHaveErrors(new Blog {Configuration = new BlogConfiguration()},x=>x.Configuration);
		}

		[Test]
		public void Should_raise_error_when_founder_is_null()
		{
			ShouldHaveErrors(new Blog {Founder = null}, x => x.Founder);
		}

		[Test]
		public void Should_raise_error_when_host_is_null()
		{
			ShouldHaveErrors(new Blog{Host=null},x=>x.Host);
			ShouldHaveErrors(new Blog {Host = ""}, x => x.Host);
			ShouldNotHaveErrors(new Blog { Host = "ccc" }, x => x.Host);
		}

		[Test]
		public void Should_raise_error_when_name_is_not_specified()
		{
			ShouldHaveErrors(new Blog{Name=null}, x => x.Name);
			ShouldHaveErrors(new Blog {Name = ""}, x => x.Name);
			ShouldNotHaveErrors(new Blog { Name = "abc" }, x => x.Name);
		}

		[Test]
		public void Should_raise_error_when_title_is_null()
		{
			ShouldHaveErrors(new Blog{Title=null},x => x.Title);
			ShouldHaveErrors(new Blog {Title = ""}, x => x.Title);
			ShouldNotHaveErrors(new Blog{Title="aa"},x=>x.Title);
		}
	}
}