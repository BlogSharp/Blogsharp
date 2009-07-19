namespace BlogSharp.Model.Tests.Validators
{
	using NUnit.Framework;
	using Validation;

	/// <summary>
	/// Test for the <see cref="UserValidator"/> class.
	/// </summary>
	[TestFixture]
	public class UserValidatorTests : ValidationTestBase<UserValidator, User>
	{
		/// <summary>
		/// Tests the Email property for bad format.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenEmailIsInInvalidFormat()
		{
			ShouldHaveErrors(x => x.Email, "aaa");
			ShouldHaveErrors(x => x.Email, "aaa@aaa");
			ShouldHaveErrors(x => x.Email, "aaa@aaa.");
			ShouldNotHaveErrors(x => x.Email, "aaa@aaa.com");
		}

		/// <summary>
		/// Tests the Email property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenEmailIsNullOrEmpty()
		{
			ShouldHaveErrors(x => x.Email, null);
			ShouldHaveErrors(x => x.Email, string.Empty);
		}

		/// <summary>
		/// Tests the Password property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenPasswordIsNullOrEmpty()
		{
			ShouldHaveErrors(x => x.Password, null);
			ShouldHaveErrors(x => x.Password, string.Empty);
		}

		/// <summary>
		/// Tests the UserName property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenUserNameIsNullOrEmpty()
		{
			ShouldHaveErrors(x => x.UserName, null);
			ShouldHaveErrors(x => x.UserName, string.Empty);
		}
	}
}