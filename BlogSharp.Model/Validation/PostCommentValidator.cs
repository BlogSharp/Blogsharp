namespace BlogSharp.Model.Validation
{
	using FluentValidation;
	using Rules;

	/// <summary>
	/// A validator for the <see cref="Comment"/> Class.
	/// </summary>
	public class CommentValidator : ValidatorBase<Comment>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommentValidator" /> class. 
		/// </summary>
		public CommentValidator()
		{
			RuleFor(x => x.Text).NotNull().NotEmpty();

			RuleFor(x => x.Commenter)
				.NotNull()
				.When(x => string.IsNullOrEmpty(x.Email) && string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Web));

			RuleFor(x => x.Name).NotEmpty().When(x => x.Commenter == null);
			RuleFor(x => x.Email).NotEmpty().When(x => x.Commenter == null);
			RuleFor(x => x.Email).EmailAddress().When(x => x.Commenter == null);
			RuleFor(x => x.Web).Url().When(x => !string.IsNullOrEmpty(x.Web) && x.Commenter == null);
		}
	}
}