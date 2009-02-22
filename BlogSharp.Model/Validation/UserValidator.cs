// <copyright file="UserValidator.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>


namespace BlogSharp.Model.Validation
{
	using FluentValidation;

	/// <summary>
	/// A Validator class for the User Class.
	/// </summary>
	public class UserValidator : ValidatorBase<User>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserValidator" /> class. 
		/// </summary>
		public UserValidator()
		{
			RuleFor(x => x.Email).NotEmpty().And().NotNull().And().EmailAddress();
			RuleFor(x => x.Password).NotNull().And().NotEmpty();
			RuleFor(x => x.Username).NotEmpty().And().NotNull();
		}
	}
}