using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model.Annotations;
using NUnit.Framework;

namespace BlogSharp.Model.Tests
{
	[TestFixture]
	public class EmailValidatorTests
	{
		[Test]
		public void Is_Email_Correctly_Validated()
		{
			EmailAttribute emailAttribute = new EmailAttribute();
			Assert.That(emailAttribute.IsValid(""), Is.True);
			Assert.That(emailAttribute.IsValid("tehlike"), Is.False);
			Assert.That(emailAttribute.IsValid("tehlike@gmail"), Is.False);
			Assert.That(emailAttribute.IsValid("tehlike@gmail.com"), Is.True);
		}
	}
}
