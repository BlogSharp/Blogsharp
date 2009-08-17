namespace BlogSharp.Core.Services.Template
{
	using System.Collections.Generic;

	public interface ITemplateContext
	{
		void Put(string key, object value);
		void Put(IDictionary<string, object> parameters);
		void Put(object anonymous);
		void Remove(string key);
		IDictionary<string, object> GetValues();
	}
}