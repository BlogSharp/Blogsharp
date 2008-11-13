using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Impl.Structure;
using BlogSharp.Core.Structure;
using Xunit;

namespace BlogSharp.Core.Impl.Tests.Structure
{
	public class FriendlyUrlGeneratorTests
	{
		public FriendlyUrlGeneratorTests()
		{
			this.generator = new FriendlyUrlGeneratorImpl();
		}

		private readonly IFriendlyUrlGenerator generator;

		[Fact]
		public void CanIgnoreNonCharacters()
		{
			string str=generator
				.GenerateUrl("blah.aspx?title={0}", "this is a sample title with 1 numbers in it");
			Assert.Equal("blah.aspx?title=this-is-a-sample-title-with-1-numbers-in-it",str);
		}
	}
}
