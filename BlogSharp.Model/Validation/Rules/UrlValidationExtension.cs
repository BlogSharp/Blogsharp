using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace BlogSharp.Model.Validation.Rules
{
	public static class UrlValidationExtension
	{
		public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder.SetValidator(new UrlValidationRule<T>());
		}
	}
}
