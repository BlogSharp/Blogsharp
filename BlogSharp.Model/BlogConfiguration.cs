using System.Collections.Generic;

namespace BlogSharp.Model
{
	public class BlogConfiguration : IEntity
	{
		private readonly IDictionary<string, object> innerDict;

		public BlogConfiguration()
		{
			innerDict = new Dictionary<string, object>(10);
		}

		public object this[string key]
		{
			get { return innerDict[key]; }
			set { innerDict[key] = value; }
		}

		public object GetValue(string key)
		{
			return innerDict[key];
		}

		public T GetValue<T>(string key)
		{
			return (T) innerDict[key];
		}

		public void SetValue(string key, object value)
		{
			innerDict[key] = value;
		}

		public void SetValue<T>(string key, T value)
		{
			innerDict[key] = value;
		}
	}
}