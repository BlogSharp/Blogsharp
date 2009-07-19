namespace BlogSharp.Model.Validation
{
	using FluentValidation;

	/// <summary>
	/// A Validator class for the <see cref="Tag" /> Class.
	/// </summary>
	public class TagValidator : ValidatorBase<Tag>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TagValidator" /> class. 
		/// </summary>
		public TagValidator()
		{
			RuleFor(x => x.Name).NotNull().And.NotEmpty();
			RuleFor(x => x.FriendlyName).NotNull().And.NotEmpty();
			RuleFor(x => x.Posts).NotEmpty();
		}
	}
}