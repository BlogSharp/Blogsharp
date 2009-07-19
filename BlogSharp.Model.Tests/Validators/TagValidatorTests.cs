namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	/// <summary>
	/// Test for the <see cref="TagValidator"/> class.
	/// </summary>
	[TestFixture]
	public class TagValidatorTests : ValidationTestBase<TagValidator, Tag>
	{
		/// <summary>
		/// Tests the FriendlyName property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenFriendlyNameIsNullOrEmpty()
		{
			ShouldHaveErrors(x => x.FriendlyName, null);
			ShouldHaveErrors(x => x.FriendlyName, string.Empty);
		}

		/// <summary>
		/// Tests the content property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenNameIsNullOrEmpty()
		{
			ShouldHaveErrors(x => x.Name, null);
			ShouldHaveErrors(x => x.Name, string.Empty);
		}

		/// <summary>
		/// Tests the Posts property for null.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenPostsIsNull()
		{
			ShouldHaveErrors(x => x.Posts, null);
		}
	}
}