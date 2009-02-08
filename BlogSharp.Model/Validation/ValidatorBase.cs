using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentValidation;

namespace BlogSharp.Model.Validation
{
	public abstract class ValidatorBase<T> : AbstractValidator<T>,IValidatorBase<T>,IValidatorBase
	{
		public virtual void ValidateAndThrowException(T instance)
		{
			var validationResult = this.Validate(instance);

			if (!validationResult.IsValid)
			{
				var errorList = validationResult.Errors
					.Select(x => new ValidationError
					{
						Message = x.ErrorMessage,
						Object = x.AttemptedValue,
						PropertyName = x.PropertyName
					}).ToList();
				throw new ValidationException { Errors = errorList };
			}
		}

		public virtual void ValidateAndThrowException(T instance,params Expression<Func<T,object>>[] expression)
		{
			var validationResult = this.Validate(instance,expression);

			if (!validationResult.IsValid)
			{
				var errorList = validationResult.Errors
					.Select(x => new ValidationError
					{
						Message = x.ErrorMessage,
						Object = x.AttemptedValue,
						PropertyName = x.PropertyName
					}).ToList();
				throw new ValidationException { Errors = errorList };
			}
		}

		#region IValidatorBase Members

		public void ValidateAndThrowException(object instance)
		{
			ValidateAndThrowException((T) instance);
		}

		#endregion
	}
}
