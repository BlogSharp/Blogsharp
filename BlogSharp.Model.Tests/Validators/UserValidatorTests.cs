namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	[TestFixture]
	public class UserValidatorTests : ValidationTestBase<UserValidator, User>
	{
		[Test]
		public void Should_raise_error_when_Email_is_in_invalid_format()
		{
			this.ShouldHaveErrors(x => x.Email, "aaa");
			this.ShouldHaveErrors(x => x.Email, "aaa@aaa");
			this.ShouldHaveErrors(x => x.Email, "aaa@aaa.");
			this.ShouldNotHaveErrors(x => x.Email, "aaa@aaa.com");
		}

		[Test]
		public void Should_raise_error_when_Email_is_null_or_empty()
		{
			this.ShouldHaveErrors(x => x.Email, null);
			this.ShouldHaveErrors(x => x.Email, "");
		}

		[Test]
		public void Should_raise_error_when_Password_is_null_or_empty()
		{
			this.ShouldHaveErrors(x => x.Password, null);
			this.ShouldHaveErrors(x => x.Password, "");
		}

		[Test]
		public void Should_raise_error_when_Username_is_null_or_empty()
		{
			this.ShouldHaveErrors(x => x.Username, null);
			this.ShouldHaveErrors(x => x.Username, "");
		}
	}
}