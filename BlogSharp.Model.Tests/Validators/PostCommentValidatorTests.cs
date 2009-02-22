namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	[TestFixture]
	public class PostCommentValidatorTests : ValidationTestBase<PostCommentValidator, PostComment>
	{
		[Test]
		public void Should_raise_error_when_comment_is_not_specified()
		{
			this.ShouldHaveErrors(x => x.Comment, null);
			this.ShouldHaveErrors(x => x.Comment, null);
		}

		[Test]
		public void Should_raise_error_when_email_is_empty()
		{
			this.ShouldHaveErrors(x => x.Email, null);
			this.ShouldHaveErrors(x => x.Email, "");
		}

		[Test]
		public void Should_raise_error_when_email_is_in_invalid_format()
		{
			this.ShouldHaveErrors(x => x.Email, "aaaa");
			this.ShouldHaveErrors(x => x.Email, "aaa@aaa");
			this.ShouldHaveErrors(x => x.Email, "aaa@aaa.");
			this.ShouldNotHaveErrors(x => x.Email, "aaa@aaa.com");
		}


		[Test]
		public void Should_raise_error_when_web_is_in_invalid_format()
		{
			this.ShouldHaveErrors(x => x.Web, "aaaa");
			this.ShouldHaveErrors(x => x.Web, "http://aaa");
			this.ShouldNotHaveErrors(x => x.Web, "http://tunatoksoz.com");
		}

		[Test]
		public void Should_raise_no_error_when_web_is_in_invalid_format()
		{
			this.ShouldNotHaveErrors(x => x.Web, "");
		}
	}
}