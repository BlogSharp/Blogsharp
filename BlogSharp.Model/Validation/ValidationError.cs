// <copyright file="ValidationError.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

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