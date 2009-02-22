namespace BlogSharp.Core.Event
{
	using System;

	public abstract class AbstractEventArgs : EventArgs, IEventArgs
	{
		private readonly object source;

		protected AbstractEventArgs(object source)
		{
			this.source = source;
		}

		#region IEventArgs Members

		public virtual object Source
		{
			get { return source; }
		}

		#endregion
	}

	public abstract class AbstractEventArgs<T> : AbstractEventArgs, IEventArgs<T>
	{
		protected AbstractEventArgs(T source) : base(source)
		{
		}

		#region IEventArgs<T> Members

		public new T Source { get; set; }

		#endregion
	}
}