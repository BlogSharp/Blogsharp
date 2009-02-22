namespace BlogSharp.Core.Impl.Tests.Structure
{
	using Core.Structure;
	using Impl.Structure;
	using NUnit.Framework;

	[TestFixture]
	public class FriendlyUrlGeneratorTests
	{
		private readonly IFriendlyUrlGenerator generator;

		public FriendlyUrlGeneratorTests()
		{
			this.generator = new FriendlyUrlGenerator();
		}

		[Test]
		public void Can_ignore_non_alphanumeric_characters()
		{
			string str = this.generator
				.GenerateUrl("blah.aspx?title={0}", "this is a sample title with 1 numbers in it");
			Assert.That(str, Is.EqualTo("blah.aspx?title=this-is-a-sample-title-with-1-numbers-in-it"));
		}
	}
}