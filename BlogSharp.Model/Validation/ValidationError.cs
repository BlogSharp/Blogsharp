using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Model.Validation
{
	public class ValidationError
	{
		public object Object { get; set; }
		public string PropertyName { get; set; }
		public string Message { get; set; }
	}
}
