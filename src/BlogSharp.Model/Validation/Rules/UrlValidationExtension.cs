namespace BlogSharp.Model.Validation.Rules
{
	using FluentValidation;

	/// <summary>
	/// Validation Extension for URLs.
	/// </summary>
	public static class UrlValidationExtension
	{
		/// <summary>
		/// The URL Validator.
		/// </summary>
		/// <param name="ruleBuilder">A Rule Builder to check the url.</param>
		/// <typeparam name="T">Part of the ruleBuilder Contructor.</typeparam>
		/// <returns>The Validator.</returns>
		public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder.SetValidator(new UrlValidationRule<T>());
		}
	}
}