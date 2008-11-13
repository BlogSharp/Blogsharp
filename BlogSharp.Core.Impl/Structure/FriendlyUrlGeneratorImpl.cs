using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BlogSharp.Core.Structure;

namespace BlogSharp.Core.Impl.Structure
{
	public class FriendlyUrlGeneratorImpl:IFriendlyUrlGenerator
	{
		private readonly Regex regex=new Regex(@"\W+");
		#region IFriendlyUrlGenerator Members
		
		public string GenerateUrl(string format, params string[] args)
		{
			var list = new List<string>();
			foreach (var s in args)
			{
				string replaced = regex.Replace(s, "-");
				list.Add(replaced);
			}
			return string.Format(format, list.ToArray());
		}
		#endregion
	}
}
