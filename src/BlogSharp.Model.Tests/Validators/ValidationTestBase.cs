namespace BlogSharp.Model.Tests.Validators
{
	using System;
	using System.Linq.Expressions;
	using FluentValidation;
	using FluentValidation.TestHelper;
	using NUnit.Framework;

	/// <summary>
	/// Base for all validators test
	/// </summary>
	/// <typeparam name="TValidator">The validator</typeparam>
	/// <typeparam name="TValidatee">The validated</typeparam>
	[TestFixture]
	public class ValidationTestBase<TValidator, TValidatee>
		where TValidator : AbstractValidator<TValidatee>, new()
		where TValidatee : class, new()

	{

		#region Setup/Teardown

		/// <summary>
		/// The SetUp of all the tests.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			validator = new TValidator();
		}

		#endregion

		/// <summary>
		/// The validator to run.
		/// </summary>
		private TValidator validator;

		protected virtual void ShouldHaveErrors(TValidatee value, Expression<Func<TValidatee, object>> expression)
		{
			var result = validator.Validate(value, expression);
			if (result.IsValid)
				throw new AssertionException("This object should not be valid");
		}

		protected virtual void ShouldNotHaveErrors(TValidatee value,Expression<Func<TValidatee,object>> expression)
		{
			var result=validator.Validate(value, expression);
			if (!result.IsValid)
				throw new AssertionException("This object should be valid");
		}

	}
}