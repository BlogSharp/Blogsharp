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
			RuleFor(x => x.Email).NotEmpty().And.NotNull().And.EmailAddress();
			RuleFor(x => x.Password).NotNull().And.NotEmpty();
			RuleFor(x => x.UserName).NotEmpty().And.NotNull();

			// this.RuleFor(x => x.BirthDate).Must(BeAValidDate);
		}

		/*
        /// <summary>
        /// Checks the date to be valid.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if valid.</returns>
        private static bool BeAValidDate(DateTime? date)
        {
            return date.HasValue && date.Value < DateTime.Now;
        }
        */
	}
}