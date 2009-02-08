using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentValidation;

namespace BlogSharp.Model.Validation
{
	public interface IValidatorBase:IValidator
	{
		void ValidateAndThrowException(object instance);
	}
	public interface IValidatorBase<T>:IValidator<T>
	{
		void ValidateAndThrowException(T instance);
	}
}
