using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace BlogSharp.Model.Validation
{
	public class BlogValidator : ValidatorBase<Blog>
	{
		public BlogValidator()
		{
			RuleFor(x => x.Configuration).NotNull();
			RuleFor(x => x.Founder).NotNull();
			RuleFor(x => x.Host).NotNull();
			RuleFor(x => x.Host).NotEmpty();
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Title).NotEmpty();
		}
	}
}
