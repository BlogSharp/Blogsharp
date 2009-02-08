using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace BlogSharp.Model.Validation
{
	public class PostValidator : ValidatorBase<Post>
	{
		public PostValidator()
		{
			RuleFor(x => x.Blog).NotNull();
			RuleFor(x => x.Content).NotNull();
			RuleFor(x => x.Content).NotEmpty();
			RuleFor(x => x.FriendlyTitle).NotEmpty();
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.User).NotNull();
		}
	}
}
