using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Validation
{
	public class ValidationException:Exception
	{
		public IEnumerable<ValidationError> Errors{ get; set; }
		public override string Message
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Validation error has occured on following properties:");
				foreach (var error in Errors)
				{
					sb.AppendLine(error.Message);
				}
				return sb.ToString();
			}
		}
	}
}
