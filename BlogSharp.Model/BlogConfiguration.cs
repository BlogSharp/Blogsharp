using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

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

		public int PageSize
		{
			get
			{
				return Get(x => x.PageSize);
			}
			set
			{
				Set(x => x.PageSize, value);
			}
		}

		public void Set<U>(Expression<Func<BlogConfiguration, U>> exp, U value)
		{
			innerDict[GetKey(exp)] = value;
		}

		public U Get<U>(Expression<Func<BlogConfiguration, U>> exp)
		{
			return (U)(innerDict[GetKey(exp)] ?? default(U));
		}

		private string GetKey<U>(Expression<Func<BlogConfiguration, U>> exp)
		{
			PropertyInfo info = ((MemberExpression) exp.Body).Member as PropertyInfo;
			return info.Name;
		}
	}
}