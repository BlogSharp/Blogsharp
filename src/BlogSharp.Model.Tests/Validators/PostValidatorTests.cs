namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	/// <summary>
	/// Test for the <see cref="PostValidator"/> class
	/// </summary>
	[TestFixture]
	public class PostValidatorTests : ValidationTestBase<PostValidator, Post>
	{
		/// <summary>
		/// Tests the Blog property for null
		/// </summary>
		[Test]
		public void Should_raise_error_when_Blog_is_null()
		{
			ShouldHaveErrors(new Post{Blog=null},x => x.Blog);
			ShouldNotHaveErrors(new Post{Blog=new Blog()},x => x.Blog);
		}

		/// <summary>
		/// Tests the content property for null or empty
		/// </summary>
		[Test]
		public void Should_raise_error_when_Content_is_null_or_empty()
		{
			ShouldHaveErrors(new Post{Content=null},x => x.Content);
			ShouldHaveErrors(new Post { Content = string.Empty }, x => x.Content);
			ShouldNotHaveErrors(new Post{Content="a"},x => x.Content);
		}

		/// <summary>
		/// Tests the FriendlyTitle property for null or empty
		/// </summary>
		[Test]
		public void Should_raise_error_when_FriendlyTitle_is_null_or_empty()
		{
			ShouldHaveErrors(new Post{FriendlyTitle=null},x => x.FriendlyTitle);
			ShouldHaveErrors(new Post{FriendlyTitle=string.Empty},x => x.FriendlyTitle);
			ShouldNotHaveErrors(new Post{FriendlyTitle="a"},x => x.FriendlyTitle);
		}

		/// <summary>
		/// Tests the Title property for null or empty
		/// </summary>
		[Test]
		public void Should_raise_error_when_Title_is_null_or_empty()
		{
			ShouldHaveErrors(new Post{Title=null},x => x.Title);
			ShouldHaveErrors(new Post{Title=string.Empty},x => x.Title);
			ShouldNotHaveErrors(new Post{Title="aaa"},x => x.Title);
		}

		/// <summary>
		/// Tests the Publisher property for null
		/// </summary>
		[Test]
		public void Should_raise_error_when_User_is_null()
		{
			ShouldHaveErrors(new Post{Publisher=null},x => x.Publisher);
		}
	}
}