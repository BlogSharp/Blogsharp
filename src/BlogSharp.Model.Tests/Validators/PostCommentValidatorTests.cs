namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	[TestFixture]
	public class PostCommentValidatorTests : ValidationTestBase<CommentValidator, Comment>
	{
		[Test]
		public void Should_raise_error_when_comment_is_not_specified()
		{
			ShouldHaveErrors(new Comment{Text=null},x=>x.Text);
			ShouldHaveErrors(new Comment {Text = string.Empty}, x => x.Text);
			ShouldNotHaveErrors(new Comment { Text = "aaaa" }, x => x.Text);
		}

		[Test]
		public void Should_raise_error_when_email_is_empty_and_no_user_is_present()
		{
			ShouldHaveErrors(new Comment { Email = null, User = null }, x => x.Email);
			ShouldHaveErrors(new Comment { Email = string.Empty, User = null }, x => x.Email);
		}

		[Test]
		public void Should_not_raise_error_when_email_is_empty_and_user_is_present()
		{
			ShouldNotHaveErrors(new Comment { Email = null, User = new User { } }, x => x.Email);
			ShouldNotHaveErrors(new Comment { Email = null, User = new User { } }, x => x.Email);
		}

		[Test]
		public void Should_raise_error_when_email_is_in_invalid_format()
		{
			ShouldHaveErrors(new Comment { Email = "aaa", User = null }, x => x.Email);
			ShouldHaveErrors(new Comment { Email = "aaa@aaa", User = null }, x => x.Email);
			ShouldHaveErrors(new Comment { Email = "aaa@aaa.", User = null }, x => x.Email);
			ShouldNotHaveErrors(new Comment { Email = "aaa@aaa.com", User = null }, x => x.Email);
		}


		[Test]
		public void Should_raise_error_when_web_is_in_invalid_format()
		{
			ShouldHaveErrors(new Comment{Web="aaa"},x=>x.Web);
			ShouldHaveErrors(new Comment { Web = "http://aaa" }, x => x.Web);
			ShouldNotHaveErrors(new Comment { Web = "http://aaa.com" }, x => x.Web);
		}

		[Test]
		public void Should_not_raise_error_when_web_is_null()
		{
			ShouldNotHaveErrors(new Comment{Web=null},x=>x.Web);
		}
	}
}