namespace BlogSharp.Model.Tests.Validators
{
	using System;
	using System.Linq.Expressions;
	using FluentValidation;
	using FluentValidation.TestHelper;
	using NUnit.Framework;

	[TestFixture]
	public class ValidationTestBase<TValidator, TValidatee>
		where TValidator : AbstractValidator<TValidatee>, new()
		where TValidatee : class, new()
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.validator = new TValidator();
		}

		#endregion

		private TValidator validator;

		protected virtual void ShouldHaveErrors<TValue>(Expression<Func<TValidatee, TValue>> expression, TValue value)
		{
			this.validator.ShouldHaveValidationErrorFor(expression, value);
		}

		protected virtual void ShouldNotHaveErrors<TValue>(Expression<Func<TValidatee, TValue>> expression, TValue value)
		{
			this.validator.ShouldNotHaveValidationErrorFor(expression, value);
		}
	}
}