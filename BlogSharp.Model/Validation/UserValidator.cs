using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace BlogSharp.Model.Validation
{
	public class UserValidator:AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x => x.Email).NotEmpty().And().NotNull().And().EmailAddress();
			RuleFor(x => x.Password).NotNull().And().NotEmpty();
			RuleFor(x => x.Username).NotEmpty().And().NotNull();
		}
	}
}
