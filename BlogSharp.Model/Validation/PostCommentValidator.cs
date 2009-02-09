using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model.Validation.Rules;
using FluentValidation;

namespace BlogSharp.Model.Validation
{
	public class PostCommentValidator : ValidatorBase<PostComment>
	{
		public PostCommentValidator()
		{
			RuleFor(x => x.Comment).NotEmpty();
			RuleFor(x => x.Email).NotEmpty().And().EmailAddress();
			RuleFor(x => x.Web).Url().When(x=>!string.IsNullOrEmpty(x.Web));
		}
	}
}
