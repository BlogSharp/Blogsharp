// <copyright file="UserValidatorTests.cs" company="BlogSharp">
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
            this.ShouldHaveErrors(x => x.Email, "aaa");
            this.ShouldHaveErrors(x => x.Email, "aaa@aaa");
            this.ShouldHaveErrors(x => x.Email, "aaa@aaa.");
            this.ShouldNotHaveErrors(x => x.Email, "aaa@aaa.com");
        }

        /// <summary>
        /// Tests the Email property for null or empty.
        /// </summary>
        [Test]
        public void TestShouldRaiseErrorWhenEmailIsNullOrEmpty()
        {
            this.ShouldHaveErrors(x => x.Email, null);
            this.ShouldHaveErrors(x => x.Email, string.Empty);
        }

        /// <summary>
        /// Tests the Password property for null or empty.
        /// </summary>
        [Test]
        public void TestShouldRaiseErrorWhenPasswordIsNullOrEmpty()
        {
            this.ShouldHaveErrors(x => x.Password, null);
            this.ShouldHaveErrors(x => x.Password, string.Empty);
        }

        /// <summary>
        /// Tests the UserName property for null or empty.
        /// </summary>
        [Test]
        public void TestShouldRaiseErrorWhenUserNameIsNullOrEmpty()
        {
            this.ShouldHaveErrors(x => x.UserName, null);
            this.ShouldHaveErrors(x => x.UserName, string.Empty);
        }
    }
}