using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Validation
{
	public class ValidationException:Exception
	{
		public IEnumerable<ValidationError> Errors{ get; set; }

	}
}
