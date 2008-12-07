using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Services.Template;

namespace BlogSharp.Core.Impl.Services.Template
{
	public class DefaultContext:ITemplateContext
	{
		public DefaultContext()
		{
			this.dictionary=new Dictionary<string, object>();
		}
		private readonly IDictionary<string, object> dictionary;
		#region ITemplateContext Members

		public void Put(string key, object value)
		{
			this.dictionary[key] = value;
		}

		public void Put(IDictionary<string, object> parameters)
		{
			foreach (var pair in parameters)
			{
				this.dictionary.Add(pair);
			}
		}

		public void Put(object anonymous)
		{
			var properties = anonymous.GetType().GetProperties();
			foreach (var info in properties)
			{
				this.dictionary[info.Name]=info.GetValue(anonymous, null);
			}
		}

		public void Remove(string key)
		{
			this.Remove(key);
		}

		public IDictionary<string, object> GetValues()
		{
			return new Dictionary<string, object>(this.dictionary);
		}

		#endregion
	}
}
