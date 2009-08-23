namespace BlogSharp.Model
{
	using System;
	using System.Collections.Generic;
	using Interfaces;

	/// <summary>
	/// A Tag into the Blog.
	/// </summary>
	[Serializable]
	public class Tag : Entity
	{
		private IList<Post> posts;
		/// <summary>
		/// Initializes a new instance of the <see cref="Tag" /> class. 
		/// </summary>
		public Tag()
		{
			this.posts = new List<Post>();
		}

		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets FriendlyName.
		/// </summary>
		public virtual string FriendlyName { get; set; }

		/// <summary>
		/// Gets or sets Posts.
		/// </summary>
		public virtual IEnumerable<Post> Posts
		{
			get
			{
				return posts;
			}
		}

		public virtual void AddPost(Post post)
		{
			if(!this.posts.Contains(post))
			{
				this.posts.Add(post);
				post.AddTag(this);
			}
		}
	}
}