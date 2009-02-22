// <copyright file="BlogConfiguration.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>


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
	public class BlogConfiguration : Entity
	{
		/// <summary>
		/// The internal dictionary used to store the config.
		/// </summary>
		private readonly IDictionary<string, object> innerDict;

		#region Contructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BlogConfiguration" /> class. 
		/// </summary>
		public BlogConfiguration()
		{
			this.innerDict = new Dictionary<string, object>(10);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets PageSize.
		/// </summary>
		public int PageSize
		{
			get { return this.Get(x => x.PageSize); }

			set { this.Set(x => x.PageSize, value); }
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets or sets a value for the given key.
		/// </summary>
		/// <param name="key">The key to store the value.</param>
		public object this[string key]
		{
			get { return this.innerDict[key]; }
			set { this.innerDict[key] = value; }
		}

		/// <summary>
		/// Gets a value for the given key.
		/// </summary>
		/// <param name="key">The key to search.</param>
		/// <returns>The associated value for such key.</returns>
		public object GetValue(string key)
		{
			return this.innerDict[key];
		}

		/// <summary>
		/// Returns a Typed (casted) value for the given key.
		/// </summary>
		/// <param name="key">The key to search.</param>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <returns>The associated value for such key.</returns>
		public T GetValue<T>(string key)
		{
			return (T) this.innerDict[key];
		}

		/// <summary>
		/// Sets a value for the given key.
		/// </summary>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		public void SetValue(string key, object value)
		{
			this.innerDict[key] = value;
		}

		/// <summary>
		/// Sets a typed value for the given key.
		/// </summary>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		/// <typeparam name="T">The Type of the value.</typeparam>
		public void SetValue<T>(string key, T value)
		{
			this.innerDict[key] = value;
		}

		/// <summary>
		/// Gets a value for a given key.
		/// </summary>
		/// <param name="exp">The expression who retults in a key name.</param>
		/// <typeparam name="U">The Type of the Key.</typeparam>
		/// <returns>The value or the default value for his type.</returns>
		public U Get<U>(Expression<Func<BlogConfiguration, U>> exp)
		{
			return (U) (this.innerDict[this.GetKey(exp)] ?? default(U));
		}

		#endregion

		#region Private members

		/// <summary>
		/// Gets the name of the key.
		/// </summary>
		/// <param name="exp">A Expression who contains a function.</param>
		/// <typeparam name="U">The type of the value of the function.</typeparam>
		/// <returns>A string containing the Name of the Key or string.Empty if not found.</returns>
		private string GetKey<U>(Expression<Func<BlogConfiguration, U>> exp)
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
			this.innerDict[this.GetKey(exp)] = value;
		}

		#endregion
	}
}