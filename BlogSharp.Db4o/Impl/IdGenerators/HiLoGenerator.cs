namespace BlogSharp.Db4o.Impl.IdGenerators
{
	using System;
	using Db4objects.Db4o.Ext;

	/// <summary>
	/// An <see cref="IIdentifierGenerator" /> that returns an <c>Int64</c>, constructed using
	/// a hi/lo algorithm.
	/// </summary>
	public class HiLoGenerator : IIdentifierGenerator
	{
		private long maxLo;
		private long hi;
		private long lo;

		public HiLoGenerator()
		{
			this.maxLo = long.MaxValue;
			this.lo = this.maxLo + 1;
		}
		public HiLoGenerator(long maxLo)
		{
			this.maxLo = maxLo;
			this.lo = maxLo + 1;
		}

		#region IIdentifierGenerator Members
		public virtual object Generate(IExtObjectContainer container, object obj)
		{
			if (this.lo > this.maxLo)
			{
				long hiVal = this.GetNewHiValue(container);
				this.lo = 1;
				this.hi = (this.maxLo) * this.hi;
			}
			return this.hi + this.lo++;
		}

		protected virtual long GetNewHiValue(IExtObjectContainer container)
		{
			long value;
			lock (container.Lock())
			{
				var objectSet = container.QueryByExample(new Identifier());
				var hiValue = objectSet[0] as Identifier;
				if (hiValue == null)
					hiValue = new Identifier { HiValue = 0 };
				hiValue.HiValue++;
				value = hiValue.HiValue;
				container.Store(hiValue);
			}
			return value;
		}


		#endregion
	}
	public class Identifier
	{
		public int HiValue { get; set; }
	}
}
