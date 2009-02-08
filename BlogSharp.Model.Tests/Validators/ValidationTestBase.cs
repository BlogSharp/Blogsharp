using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentValidation;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace BlogSharp.Model.Tests.Validators
{
	[TestFixture]
	public class ValidationTestBase<TValidator,TValidatee> 
		where TValidator : AbstractValidator<TValidatee>, new()
		where TValidatee:class,new()
	{
		[SetUp]
		public void SetUp()
		{
			this.validator = new TValidator();
		}

		private TValidator validator;

		protected virtual void ShouldHaveErrors<TValue>(Expression<Func<TValidatee,TValue>> expression,TValue value)
		{
			validator.ShouldHaveValidationErrorFor(expression,value);
		}

		protected virtual void ShouldNotHaveErrors<TValue>(Expression<Func<TValidatee, TValue>> expression, TValue value)
		{
			validator.ShouldNotHaveValidationErrorFor(expression, value);
		}
	}
}
