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

			ShouldHaveErrors(new User{Email="aa@aaa"}, x => x.Email);
			ShouldHaveErrors(new User { Email = "aa@aaa." }, x => x.Email);
			ShouldNotHaveErrors(new User {Email = "aa@aaa.com"}, x => x.Email);
		}

		/// <summary>
		/// Tests the Email property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenEmailIsNullOrEmpty()
		{
			ShouldHaveErrors(new User{Email = null}, x => x.Email);
			ShouldHaveErrors(new User{Email=""}, x => x.Email);
		}

		/// <summary>
		/// Tests the Password property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenPasswordIsNullOrEmpty()
		{
			ShouldHaveErrors(new User{Password=null},x=>x.Password);
			ShouldHaveErrors(new User{Password = ""},x=>x.Password);
		}

		/// <summary>
		/// Tests the UserName property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenUserNameIsNullOrEmpty()
		{
			ShouldHaveErrors(new User {UserName=null }, x => x.UserName);
			ShouldHaveErrors(new User { UserName = "" }, x => x.UserName);
		}
	}
}