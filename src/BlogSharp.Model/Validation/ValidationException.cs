namespace BlogSharp.Model.Validation
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	/// <summary>
	/// Exception generated after a validation.
	/// </summary>
	public class ValidationException : Exception
	{
		/// <summary>
		/// Gets or sets Errors.
		/// </summary>
		public IEnumerable<ValidationError> Errors { get; set; }

		/// <summary>
		/// Gets Message.
		/// </summary>
		public override string Message
		{
			get
			{
				var sb = new StringBuilder();
				sb.AppendLine("Validation error has occurred on following properties:");
				foreach (var error in Errors)
				{
					sb.AppendLine(error.Message);
				}

				return sb.ToString();
			}
		}
	}
}