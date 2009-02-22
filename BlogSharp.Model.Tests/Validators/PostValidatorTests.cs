namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	[TestFixture]
	public class PostValidatorTests : ValidationTestBase<PostValidator, Post>
	{
		[Test]
		public void Should_raise_error_when_Blog_is_null()
		{
			ShouldHaveErrors(x => x.Blog, null);
		}

		[Test]
		public void Should_raise_error_when_Content_is_null_or_empty()
		{
			ShouldHaveErrors(x => x.Content, null);
			ShouldHaveErrors(x => x.Content, "");
		}

		[Test]
		public void Should_raise_error_when_FriendlyTitle_is_null_or_empty()
		{
			ShouldHaveErrors(x => x.FriendlyTitle, null);
			ShouldHaveErrors(x => x.FriendlyTitle, "");
		}

		[Test]
		public void Should_raise_error_when_Title_is_null_or_empty()
		{
			ShouldHaveErrors(x => x.Title, null);
			ShouldHaveErrors(x => x.Title, "");
		}

		[Test]
		public void Should_raise_error_when_User_is_null()
		{
			ShouldHaveErrors(x => x.User, null);
		}
	}
}