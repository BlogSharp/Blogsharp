namespace BlogSharp.Model.Validation
{
	using FluentValidation;

	/// <summary>
	/// Validator for the Blog Class.
	/// </summary>
	public class BlogValidator : ValidatorBase<Blog>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BlogValidator" /> class. 
		/// </summary>
		public BlogValidator()
		{
			RuleFor(x => x.Configuration).NotNull();
			RuleFor(x => x.Founder).NotNull();
			RuleFor(x => x.Host).NotNull().And.NotEmpty();
			RuleFor(x => x.Name).NotNull().And.NotEmpty();
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.IsInitialized).NotNull();
		}
	}
}