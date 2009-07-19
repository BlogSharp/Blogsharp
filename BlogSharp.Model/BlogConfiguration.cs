namespace BlogSharp.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Reflection;

	/// <summary>
	/// Represents the Blog Configuration.
	/// </summary>
	[Serializable]
	public class BlogConfiguration
	{
		/// <summary>
		/// The internal dictionary used to store the configuration.
		/// </summary>
		private readonly IDictionary<string, object> innerDict;

		#region Contructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BlogConfiguration" /> class. 
		/// </summary>
		public BlogConfiguration()
		{
			innerDict = new Dictionary<string, object>(10);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets PageSize.
		/// </summary>
		public virtual int PageSize
		{
			get { return Get(x => x.PageSize); }

			set { Set(x => x.PageSize, value); }
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets or sets a value for the given key.
		/// </summary>
		/// <param name="key">The key to store the value.</param>
		public virtual object this[string key]
		{
			get { return innerDict[key]; }
			set { innerDict[key] = value; }
		}

		/// <summary>
		/// Gets a value for the given key.
		/// </summary>
		/// <param name="key">The key to search.</param>
		/// <returns>The associated value for such key.</returns>
		public virtual object GetValue(string key)
		{
			return innerDict[key];
		}

		/// <summary>
		/// Returns a Typed (casted) value for the given key.
		/// </summary>
		/// <param name="key">The key to search.</param>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <returns>The associated value for such key.</returns>
		public virtual T GetValue<T>(string key)
		{
			return (T) innerDict[key];
		}

		/// <summary>
		/// Sets a value for the given key.
		/// </summary>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		public virtual void SetValue(string key, object value)
		{
			innerDict[key] = value;
		}

		/// <summary>
		/// Sets a typed value for the given key.
		/// </summary>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		/// <typeparam name="T">The Type of the value.</typeparam>
		public virtual void SetValue<T>(string key, T value)
		{
			innerDict[key] = value;
		}

		/// <summary>
		/// Gets a value for a given key.
		/// </summary>
		/// <param name="exp">The expression who results in a key name.</param>
		/// <typeparam name="U">The Type of the Key.</typeparam>
		/// <returns>The value or the default value for his type.</returns>
		/// <exception cref="System.InvalidCastException">This conversion is not supported or value is null and conversionType is a value type.</exception>
		/// <exception cref="System.ArgumentNullException">ConversionType is null.</exception>
		public virtual U Get<U>(Expression<Func<BlogConfiguration, U>> exp)
		{
			return (U) Convert.ChangeType(innerDict[GetKey(exp)] ?? default(U), typeof (U));
		}

		#endregion

		#region Private members

		/// <summary>
		/// Gets the name of the key.
		/// </summary>
		/// <param name="exp">A Expression who contains a function.</param>
		/// <typeparam name="U">The type of the value of the function.</typeparam>
		/// <returns>A string containing the Name of the Key or string.Empty if not found.</returns>
		private static string GetKey<U>(Expression<Func<BlogConfiguration, U>> exp)
		{
			var info = ((MemberExpression) exp.Body).Member as PropertyInfo;

			return info != null ? info.Name : string.Empty;
		}

		/// <summary>
		/// Sets a value for a given Key.
		/// </summary>
		/// <param name="exp">A Expression who contains a function.</param>
		/// <param name="value">The value to set.</param>
		/// <typeparam name="U">The type of the value of the function.</typeparam>
		private void Set<U>(Expression<Func<BlogConfiguration, U>> exp, U value)
		{
			innerDict[GetKey(exp)] = value;
		}

		#endregion
	}
}