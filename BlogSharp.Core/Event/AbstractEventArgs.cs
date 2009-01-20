using System;

namespace BlogSharp.Core.Event
{
	public abstract class AbstractEventArgs : EventArgs,IEventArgs
	{
		protected AbstractEventArgs(object source)
		{
			this.source = source;
		}
		public virtual object Source { get { return source; } }
		private  object source;
	}
	public abstract class AbstractEventArgs<T> : AbstractEventArgs,IEventArgs<T>
	{
		protected AbstractEventArgs(T source):base(source)
		{
			
		}
		public new T Source { get; set; }
	}
}
