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
			this.ShouldHaveErrors(x => x.Blog, null);
		}

		[Test]
		public void Should_raise_error_when_Content_is_null_or_empty()
		{
			this.ShouldHaveErrors(x => x.Content, null);
			this.ShouldHaveErrors(x => x.Content, "");
		}

		[Test]
		public void Should_raise_error_when_FriendlyTitle_is_null_or_empty()
		{
			this.ShouldHaveErrors(x => x.FriendlyTitle, null);
			this.ShouldHaveErrors(x => x.FriendlyTitle, "");
		}

		[Test]
		public void Should_raise_error_when_Title_is_null_or_empty()
		{
			this.ShouldHaveErrors(x => x.Title, null);
			this.ShouldHaveErrors(x => x.Title, "");
		}

		[Test]
		public void Should_raise_error_when_User_is_null()
		{
			this.ShouldHaveErrors(x => x.User, null);
		}
	}
}