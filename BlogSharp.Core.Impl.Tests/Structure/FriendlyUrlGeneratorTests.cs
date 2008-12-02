using BlogSharp.Core.Impl.Structure;
using BlogSharp.Core.Structure;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Structure
{
	public class FriendlyUrlGeneratorTests
	{
		private readonly IFriendlyUrlGenerator generator;

		public FriendlyUrlGeneratorTests()
		{
			generator = new FriendlyUrlGeneratorImpl();
		}

		[Fact]
		public void Can_ignore_non_alphanumeric_characters()
		{
			string str = generator
				.GenerateUrl("blah.aspx?title={0}", "this is a sample title with 1 numbers in it");
			Assert.Equal("blah.aspx?title=this-is-a-sample-title-with-1-numbers-in-it", str);
		}
	}
}