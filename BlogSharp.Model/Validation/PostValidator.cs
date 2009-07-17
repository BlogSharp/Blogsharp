// <copyright file="PostValidator.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model.Validation
{
	using FluentValidation;

	/// <summary>
	/// A Validator class for the <see cref="Post" /> Class.
	/// </summary>
	public class PostValidator : ValidatorBase<Post>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PostValidator" /> class. 
		/// </summary>
		public PostValidator()
		{
			RuleFor(x => x.Blog).NotNull();
			RuleFor(x => x.Content).NotNull().And.NotEmpty();
			RuleFor(x => x.FriendlyTitle).NotEmpty();
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.Publisher).NotNull();
		}
	}
}