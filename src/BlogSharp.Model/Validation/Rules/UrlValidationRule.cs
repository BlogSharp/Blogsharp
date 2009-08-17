namespace BlogSharp.Model.Validation.Rules
{
	using FluentValidation.Validators;

	/// <summary>
	/// A Validation Rule for URLs.
	/// </summary>
	/// <typeparam name="T">Type to validate.</typeparam>
	public class UrlValidationRule<T> : RegularExpressionValidator<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UrlValidationRule{T}" /> class. 
		/// </summary>
		public UrlValidationRule()
			: base(
				@"^(?#Protocol)(?:(?:ht|f)tp(?:s?)\:\/\/|~/|/)?(?#Username:Password)(?:\w+:\w+@)?(?#Subdomains)(?:(?:[-\w]+\.)+(?#TopLevel Domains)(?:com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum|travel|[a-z]{2}))(?#Port)(?::[\d]{1,5})?(?#Directories)(?:(?:(?:/(?:[-\w~!$+|.,=]|%[a-f\d]{2})+)+|/)+|\?|#)?(?#Query)(?:(?:\?(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)(?:&(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)*)*(?#Anchor)(?:#(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)?$"
				)
		{
		}
	}
}