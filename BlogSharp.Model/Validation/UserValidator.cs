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
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Email).NotNull();
			RuleFor(x => x.Password).NotNull();
			RuleFor(x => x.Password).NotEmpty();
			RuleFor(x => x.Username).NotNull();
			RuleFor(x => x.Username).NotEmpty();
		}
	}
}
