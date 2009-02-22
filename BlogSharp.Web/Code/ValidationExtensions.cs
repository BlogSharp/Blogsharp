namespace BlogSharp.Web.Code
{
	using System.Web.Mvc;
	using Model.Validation;

	public static class ValidationExtensions
	{
		public static void AddValidationExceptionToModel(this ModelStateDictionary model, string prefix,
		                                                 ValidationException exception)
		{
			var errors = exception.Errors;
			foreach (var error in errors)
			{
				model.AddModelError(string.Format("{0}.{1}", prefix, error.PropertyName), error.Message);
			}
		}
	}
}