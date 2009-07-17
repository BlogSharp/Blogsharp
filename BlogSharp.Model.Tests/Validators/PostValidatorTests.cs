// <copyright file="PostValidatorTests.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

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
			ShouldHaveErrors(x => x.Blog, null);
		}

		/// <summary>
		/// Tests the content property for null or empty
		/// </summary>
		[Test]
		public void Should_raise_error_when_Content_is_null_or_empty()
		{
			ShouldHaveErrors(x => x.Content, null);
			ShouldHaveErrors(x => x.Content, string.Empty);
		}

		/// <summary>
		/// Tests the FriendlyTitle property for null or empty
		/// </summary>
		[Test]
		public void Should_raise_error_when_FriendlyTitle_is_null_or_empty()
		{
			ShouldHaveErrors(x => x.FriendlyTitle, null);
			ShouldHaveErrors(x => x.FriendlyTitle, string.Empty);
		}

		/// <summary>
		/// Tests the Title property for null or empty
		/// </summary>
		[Test]
		public void Should_raise_error_when_Title_is_null_or_empty()
		{
			ShouldHaveErrors(x => x.Title, null);
			ShouldHaveErrors(x => x.Title, string.Empty);
		}

		/// <summary>
		/// Tests the Publisher property for null
		/// </summary>
		[Test]
		public void Should_raise_error_when_User_is_null()
		{
			ShouldHaveErrors(x => x.Publisher, null);
		}
	}
}