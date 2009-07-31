namespace BlogSharp.Model.Tests.Validators
{
	using System.Collections.Generic;
	using Interfaces;
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
			ShouldHaveErrors(new Tag{FriendlyName=null},x => x.FriendlyName);
			ShouldHaveErrors(new Tag {FriendlyName = string.Empty}, x => x.FriendlyName);
			ShouldNotHaveErrors(new Tag{FriendlyName = "blabla"},x=>x.FriendlyName);
		}

		/// <summary>
		/// Tests the content property for null or empty.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenNameIsNullOrEmpty()
		{
			ShouldHaveErrors(new Tag{Name=null}, x => x.Name);
			ShouldHaveErrors(new Tag {Name = string.Empty}, x => x.Name);
			ShouldNotHaveErrors(new Tag{Name="aaa"},x=>x.Name);
		}

		/// <summary>
		/// Tests the Posts property for null.
		/// </summary>
		[Test]
		public void TestShouldRaiseErrorWhenPostsIsNull()
		{
			ShouldHaveErrors(new Tag {Posts = null}, x => x.Posts);
			ShouldNotHaveErrors(new Tag{Posts=new List<Post>()}, x => x.Posts);
		}
	}
}