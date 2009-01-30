using System.Collections.Generic;

namespace BlogSharp.Core.Services.Template
{
	public interface ITemplateContext
	{
		void Put(string key, object value);
		void Put(IDictionary<string, object> parameters);
		void Put(object anonymous);
		void Remove(string key);
		IDictionary<string, object> GetValues();
	}
}