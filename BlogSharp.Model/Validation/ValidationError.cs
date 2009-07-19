namespace BlogSharp.Model.Validation
{
	/// <summary>
	/// An Error during the Validation Process.
	/// </summary>
	public class ValidationError
	{
		/// <summary>
		/// Gets or sets Object.
		/// </summary>
		public object Object { get; set; }

		/// <summary>
		/// Gets or sets PropertyName.
		/// </summary>
		public string PropertyName { get; set; }

		/// <summary>
		/// Gets or sets Message.
		/// </summary>
		public string Message { get; set; }
	}
}