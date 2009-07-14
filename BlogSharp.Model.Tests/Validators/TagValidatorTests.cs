// <copyright file="TagValidatorTests.cs" company="BlogSharp">
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
    /// Test for the <see cref="TagValidator"/> class.
    /// </summary>
    [TestFixture]
    public class TagValidatorTests : ValidationTestBase<TagValidator, Tag>
    {
        /// <summary>
        /// Tests the content property for null or empty.
        /// </summary>
        [Test]
        public void TestShouldRaiseErrorWhenNameIsNullOrEmpty()
        {
            this.ShouldHaveErrors(x => x.Name, null);
            this.ShouldHaveErrors(x => x.Name, string.Empty);
        }

        /// <summary>
        /// Tests the FriendlyName property for null or empty.
        /// </summary>
        [Test]
        public void TestShouldRaiseErrorWhenFriendlyNameIsNullOrEmpty()
        {
            this.ShouldHaveErrors(x => x.FriendlyName, null);
            this.ShouldHaveErrors(x => x.FriendlyName, string.Empty);
        }

        /// <summary>
        /// Tests the Posts property for null.
        /// </summary>
        [Test]
        public void TestShouldRaiseErrorWhenPostsIsNull()
        {
            this.ShouldHaveErrors(x => x.Posts, null);
        }
    }
}
