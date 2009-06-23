// <copyright file="BlogValidator.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

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
			this.RuleFor(x => x.Configuration).NotNull();
			this.RuleFor(x => x.Founder).NotNull();
			this.RuleFor(x => x.Host).NotNull().And.NotEmpty();
			this.RuleFor(x => x.Name).NotNull().And.NotEmpty();
			this.RuleFor(x => x.Title).NotEmpty();
		    this.RuleFor(x => x.IsInitialized).NotNull();
		}
	}
}