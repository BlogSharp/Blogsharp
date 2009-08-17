

namespace BlogSharp.Model
{
	using System;

	public class Feedback:Entity
	{
		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		public virtual string Name { get; set; }


		/// <summary>
		/// Gets or sets Feedback.
		/// </summary>
		public virtual string Text { get; set; }

		/// <summary>
		/// Gets or sets Date.
		/// </summary>
		public virtual DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether Published.
		/// </summary>
		public virtual bool Published { get; set; }


		/// <summary>
		/// Gets or sets a value indicating whether Spam.
		/// </summary>
		public virtual int Spam { get; set; }


	}
}
