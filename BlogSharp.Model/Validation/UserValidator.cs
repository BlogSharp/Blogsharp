// <copyright file="UserValidator.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model.Validation
{
    using System;
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
			this.RuleFor(x => x.Email).NotEmpty().And.NotNull().And.EmailAddress();
			this.RuleFor(x => x.Password).NotNull().And.NotEmpty();
			this.RuleFor(x => x.Username).NotEmpty().And.NotNull();
		    // this.RuleFor(x => x.BirthDate).Must(BeAValidDate);
		}

	    /// <summary>
	    /// Checks the date to be valid.
	    /// </summary>
	    /// <param name="date">The date to check.</param>
	    /// <returns>True if valid.</returns>
	    private static bool BeAValidDate(DateTime? date)
	    {
	        return date.HasValue && date.Value < DateTime.Now;
	    }
	}
}