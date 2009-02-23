

namespace BlogSharp.Db4o.Impl.IdGenerators
{
	using System;

	/// <summary>
	/// .Net Guid generator.
	/// </summary>
	public class GuidGenerator : IIdentifierGenerator
	{
		#region IIdentifierGenerator Members

		public object Generate(Db4objects.Db4o.Ext.IExtObjectContainer container, object obj)
		{
			return Guid.NewGuid();
		}

		#endregion
	}
}
