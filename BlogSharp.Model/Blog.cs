// <copyright file="Blog.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>


namespace BlogSharp.Model
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// The Blog Main Class.
	/// </summary>
	[Serializable]
	public class Blog : Entity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Blog" /> class. 
		/// </summary>
		public Blog()
		{
			Authors = new List<User>();
			Posts = new List<Post>();
		}

		/// <summary>
		/// Gets or sets Configuration.
		/// </summary>
		public BlogConfiguration Configuration { get; set; }

		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets Founder.
		/// </summary>
		public User Founder { get; set; }

		/// <summary>
		/// Gets or sets Authors.
		/// </summary>
		public IList<User> Authors { get; set; }

		/// <summary>
		/// Gets or sets Posts.
		/// </summary>
		public IList<Post> Posts { get; set; }

		/// <summary>
		/// Gets or sets Title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets Host.
		/// </summary>
		public string Host { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether IsInitialized.
		/// </summary>
		public bool IsInitialized { get; set; }
	}
}